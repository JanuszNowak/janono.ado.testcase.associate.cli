using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spectre.Console;

namespace janono.ado.testcase.associate.cli
{
    public class Program
    {
        private static string path;

        private static string authValue;

        private static Action action;

        public static int Main(string[] args)
        {
            var optionAuthenticationType = new Option<AuthenticationMethod>(aliases: new string[] { "--authMethod", "-am" }, description: "Authentication method Oauth Token, PAT,Basic") { IsRequired = true };
            var optionAuthenticationToken = new Option<string>("--authValue", description: "The password, Personal Access Token or OAuth Token to authenticate") { IsRequired = true };
            var optionAction = new Option<Action>(aliases: new string[] { "--action" }, description: "Action") { IsRequired = true };
            var optionPath = new Option<string>(aliases: new string[] { "--path" }, description: "Path to dll with tests, supporting '*' wildcards.") { IsRequired = true };

            var rootCommand = new RootCommand
            {
                optionAuthenticationType,
                optionAuthenticationToken,
                optionAction,
                optionPath
            };
            rootCommand.Description = "A app for automatically associate automated tests with test cases cli.";

            rootCommand.Handler = CommandHandler.Create<AuthenticationMethod, string?, Action, string>((optionAuthenticationType, optionAuthenticationToken, optionAction, optionPath) =>
            {
                DoWork(optionAuthenticationType, authValue, optionAction, path);
            });
            AnsiConsole.Write(new FigletText("janono.ado.testcase.associate.cli").Color(new Color(102, 51, 153)));

            // fix for System.CommandLine not able to get string from input
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--authValue")
                {
                    authValue = args[i + 1];
                }

                if (args[i] == "--path")
                {
                    path = args[i + 1];
                }

                if (args[i] == "--action")
                {
                    action = (janono.ado.testcase.associate.cli.Action)Enum.Parse(typeof(janono.ado.testcase.associate.cli.Action), args[i + 1].ToString());
                }
            }

            return rootCommand.Invoke(args);
        }

        internal static void DoWork(AuthenticationMethod optionAuthenticationType, string optionAuthenticationToken, Action optionAction, string path)
        {
            optionAction = action;
            var associationList = ScanAssemblyForTestCase(path);

            var table = new Table() { Title = new TableTitle("Tests found in assemblies") };
            table.AddColumn("Organization");
            table.AddColumn("Assembly");
            table.AddColumn("Method");
            table.AddColumn("TestCaseId");

            foreach (Association x in associationList)
            {
                table.AddRow(x.Organization, x.Assembly, x.Method, x.TestCaseId.ToString());
            }

            AnsiConsole.Write(table);

            var client = GetHttpAdoClient("PAT", authValue);

            if ((optionAction == Action.List) || (optionAction == Action.Associate))
            {
                table = new Table() { Title = new TableTitle("Tests found in assemblies update insert need") };
                table.AddColumn("Organization");
                table.AddColumn("Assembly");
                table.AddColumn("Method");
                table.AddColumn("TestCaseId");
                table.AddColumn("NeedUpdateInsert");

                CheckAssignedAutomationOnOrganizationList(associationList, client);

                foreach (Association x in associationList)
                {
                    table.AddRow(x.Organization, x.Assembly, x.Method, x.TestCaseId.ToString(), x.NeedUpdateInsert.ToString());
                }

                AnsiConsole.Write(table);
            }

            if (optionAction == Action.Associate)
            {
                table = new Table() { Title = new TableTitle("Tests assosication status") };
                table.AddColumn("Organization");
                table.AddColumn("Assembly");
                table.AddColumn("Method");
                table.AddColumn("TestCaseId");
                table.AddColumn("StatusCode");

                AssigneAutomationList(associationList, client);

                foreach (Association x in associationList.Where(x => x.NeedUpdateInsert == true))
                {
                    table.AddRow(x.Organization, x.Assembly, x.Method, x.TestCaseId.ToString(), x.StatusCode);
                }

                AnsiConsole.Write(table);
            }
        }

        public static HttpClient GetHttpAdoClient(string authType, string authValue)
        {
            HttpClient client = new HttpClient();
            var pat = authValue;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{string.Empty}:{pat}")));
            return client;
        }

        public static void AssigneAutomationList(List<Association> assoscationList, HttpClient client)
        {
            Parallel.ForEach(assoscationList.Where(x => x.NeedUpdateInsert == true), x =>
            {
                AssigneAutomation(x, client);
            });
        }

        public static void CheckAssignedAutomationOnOrganizationList(List<Association> assoscationList, HttpClient client)
        {
            //foreach (Association x in assoscationList)
            //{
            //    CheckAssignedAutomationOnOrganization(x);
            //}

            Parallel.ForEach(assoscationList, new ParallelOptions { MaxDegreeOfParallelism = 16 }, x =>
            {
                CheckAssignedAutomationOnOrganization(x, client);
            });
        }

        public static List<Association> ScanAssemblyForTestCase(string path)
        {
            Assembly assm = AssemblyLoader.LoadWithDependencies(path);

            Type[] types = null;
            AppDomain appDomain = AppDomain.CurrentDomain;

            try
            {
                types = assm.GetTypes();
                //foreach (Type type in types)
                //{
                // Console.WriteLine(type.FullName);
                //}
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex);
            }
            finally
            {
            }

            var methods = types.SelectMany(x => x.GetMethods())
                    .Where(y => y.GetCustomAttributes().OfType<janono.ado.testcase.associate.TestCaseAttribute>().Any())
                    .ToDictionary(z => z.DeclaringType.FullName + "." + z.Name);

            var associationList = new List<Association>();
            foreach (var entry in methods)
            {
                var classAttribute = entry.Value.ReflectedType.GetCustomAttributes(typeof(janono.ado.testcase.associate.OrganizationAttribute), false);
                var org = ((janono.ado.testcase.associate.OrganizationAttribute)classAttribute[0]).OrganizationName;
                var attrs = entry.Value.GetCustomAttributes(typeof(janono.ado.testcase.associate.TestCaseAttribute), false);
                var b = ((janono.ado.testcase.associate.TestCaseAttribute)attrs[0]).testCaseId;
                var assemblyStorage = entry.Value.ReflectedType.Assembly.ManifestModule.Name;
                var association = new Association() { Organization = org.ToString(), Assembly = assemblyStorage.ToString(), Method = entry.Value.DeclaringType.FullName + "." + entry.Value.Name, TestCaseId = b };
                associationList.Add(association);
            }

            var c = associationList.GroupBy(x => x.TestCaseId);
            var d = c.Where(c => c.Count() > 1).ToList();
            if (d.Count() > 0)
            {
                Exception ex = new Exception("More then one uniqe assosication exist in assocaition");
                ex.Data.Add("More_Then_One_Association", d);
                throw ex;
            }

            return associationList;
        }

        public class Element
        {
            public string op { get; set; }

            public string path { get; set; }

            public string value { get; set; }
        }

        public static async void AssigneAutomation(Association aso, HttpClient client)
        {
            try
            {
                var payload = new Element[]
                {
                        new Element
                        {
                            op = "add",
                            path = "/fields/Microsoft.VSTS.TCM.AutomatedTestName",
                            value = aso.Method
                        },
                        new Element
                        {
                            op = "add",
                            path = "/fields/Microsoft.VSTS.TCM.AutomatedTestStorage",
                            value = aso.Assembly
                        },
                        new Element
                        {
                            op = "add",
                            path = "/fields/Microsoft.VSTS.TCM.AutomatedTestId",
                            value = Guid.NewGuid().ToString()
                        },
                        new Element
                        {
                            op = "add",
                            path = "/fields/Microsoft.VSTS.TCM.AutomationStatus",
                            value = "Automated"
                        }
                };

                var stringPayload = System.Text.Json.JsonSerializer.Serialize(payload);

                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json-patch+json");
                string url = $"https://{aso.Organization}.visualstudio.com/DefaultCollection/_apis/wit/workitems/{aso.TestCaseId}?api-version=1.0";
                using (HttpResponseMessage response = client.PatchAsync(url, httpContent).Result)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    aso.StatusCode = response.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex);
            }
        }

        public static async void CheckAssignedAutomationOnOrganization(Association aso, HttpClient client)
        {
            try
            {
                string url = $"https://{aso.Organization}.visualstudio.com/DefaultCollection/_apis/wit/workitems/{aso.TestCaseId}?api-version=1.0";
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    ResponseWorkItem data = JsonConvert.DeserializeObject<ResponseWorkItem>(responseBody);

                    bool needupdate = false;
                    if (!string.IsNullOrEmpty(data.fields.MicrosoftVSTSTCMAutomatedTestId))
                    {
                        aso.AutomatedTestId = Guid.Parse(data.fields.MicrosoftVSTSTCMAutomatedTestId);
                    }
                    else
                    {
                        needupdate = true;
                    }

                    if (aso.Method != data.fields.MicrosoftVSTSTCMAutomatedTestName)
                    {
                        needupdate = true;
                    }

                    if (aso.Assembly != data.fields.MicrosoftVSTSTCMAutomatedTestStorage)
                    {
                        needupdate = true;
                    }

                    // todo what to do when not found
                    // if (needupdate == true)
                    {
                        aso.NeedUpdateInsert = needupdate;
                    }

                    // tod decition make if need or not ned to update
                    // Console.WriteLine(data);
                    // AnsiConsole.Write(responseBody);
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex);
            }
        }
    }
}