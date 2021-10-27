using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace janono.ado.testcase.associate.cli.unittests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void MainMethod_Should_Ask_For_RequiredParameters()
        {
            // Arrange
            string[] input = System.Array.Empty<string>();

            // Act
            // Assert
            using (StringWriter sw = new StringWriter())
            {
                Console.SetError(sw);

                var a = janono.ado.testcase.associate.cli.Program.Main(input);
                string expected = "Option '--path' is required.";
                Assert.IsTrue(sw.ToString().Contains(expected));
                Assert.AreEqual(a, 1);
            }
        }

        //[TestMethod]
        //public void ScanAssemblyForTestCase_Should_Return_3_Methods()
        //{
        //    // Arrange
        //    string path = @"D:\repos\github\janusznowak\janono.ado.testcase.associate\janono.ado.testcase.associate.cli\samples\sample.for.t_ests.01\sample.for_unit_t_est.01\bin\Debug\net6.0\sample.for_unit_t_est.01.dll";

        //    // Act
        //    var a = janono.ado.testcase.associate.cli.Program.ScanAssemblyForTestCase(path);

        //    // Assert
        //    Assert.AreEqual(a.Count, 3);
        //}

        //[TestMethod]
        //public void ScanAssemblyForTestCase_ShouldThrowExceptioWhen_MoreThenOneAssociationExistToOneTestCase()
        //{

        //    try
        //    {
        //        string path = @"D:\repos\github\janusznowak\janono.ado.testcase.associate\janono.ado.testcase.associate.cli\samples\sample.for_unit_t_est.02\bin\Debug\net6.0\sample.for_unit_t_est.02.dll";

        //        // Act
        //        var a = janono.ado.testcase.associate.cli.Program.ScanAssemblyForTestCase(path);

        //        // Assert
        //        Assert.Fail("no exception thrown");
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.IsTrue(ex.Message.Contains("More then one uniqe assosication exist in assocaition"));
        //    }
        //}

        //[TestMethod]
        //public void Test1()
        //{
        //    // Arrange
        //    HttpClient client = janono.ado.testcase.associate.cli.Program.GetHttpAdoClient("PAT", "");
        //    List<Association> assoscationList = new List<Association>();
        //    for (int i = 11; i <= 99; i++)
        //    {
        //        assoscationList.Add(new Association() { Organization = "janono-pub", AutomatedTestId = Guid.NewGuid(), TestCaseId = i, Assembly = "xx", Method = "testmethod" + i });
        //    }

        //    // Act
        //    janono.ado.testcase.associate.cli.Program.CheckAssignedAutomationOnOrganizationList(assoscationList, client);

        //    foreach (Association ass in assoscationList)
        //    {
        //        ass.NeedUpdateInsert = true;
        //    }

        //    janono.ado.testcase.associate.cli.Program.AssigneAutomationList(assoscationList, client);

        //    // Assert
        //    foreach (Association ass in assoscationList)
        //    {
        //        Assert.AreEqual(ass.StatusCode, "OK");
        //    }
        //}

        ////[TestMethod]
        ////public void Test2()
        ////{
        ////    // Arrange
        ////    string[] input = System.Array.Empty<string>();


        ////    // Act
        ////    // Assert
        ////    using (StringWriter sw = new StringWriter())
        ////    {
        ////        Console.SetError(sw);

        ////        var a = janono.ado.testcase.associate.cli.Program.Main(input);
        ////        string expected = "Option '--path' is required.";
        ////        Assert.IsTrue(sw.ToString().Contains(expected));
        ////        Assert.AreEqual(a, 1);
        ////    }
        ////}
    }
}
