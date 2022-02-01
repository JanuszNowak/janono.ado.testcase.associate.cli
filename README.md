# janono.ado.testcase.associate.cli
 janono.ado.testcase.associate.cli
 [![Build Status](https://dev.azure.com/janono-pub/Janono.Ado.TestCase.Associate/_apis/build/status/janono.ado.testcase.associate.cli-ci?branchName=master)](https://dev.azure.com/janono-pub/Janono.Ado.TestCase.Associate/_build/latest?definitionId=34&branchName=master)

[![NuGet](https://img.shields.io/nuget/v/janono.ado.testcase.associate.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/janono.ado.testcase.associate.cli/)

[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=bugs)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=code_smells)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=coverage)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=ncloc)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=alert_status)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=security_rating)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=sqale_index)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=JanuszNowak_janono.ado.testcase.associate.cli&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)

[![Quality gate](https://sonarcloud.io/api/project_badges/quality_gate?project=JanuszNowak_janono.ado.testcase.associate.cli)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)

[![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-white.svg)](https://sonarcloud.io/dashboard?id=JanuszNowak_janono.ado.testcase.associate.cli)


![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/janono-pub/Janono.Ado.TestCase.Associate/34)
![Azure DevOps tests](https://img.shields.io/azure-devops/tests/janono-pub/Janono.Ado.TestCase.Associate/34)
![Azure DevOps builds (branch)](https://img.shields.io/azure-devops/build/janono-pub/Janono.Ado.TestCase.Associate/34/master?label=master)
![Nuget](https://img.shields.io/nuget/dt/janono.ado.testcase.associate.cli)


https://docs.microsoft.com/en-us/azure/devops/test/associate-automated-test-with-test-case?view=azure-devops



Create Test Porject or open existing, supported any with MSTest, NUnit, xUnit writen in .NET Core or .NET Framework version.

Add latest nuget package "janono.ado.testcase.associate" from https://www.nuget.org/packages/janono.ado.testcase.associate/


On Test Class level add organization atrribute [janono.ado.testcase.associate.Organization("janono-pub")] where value "janono-pub" points to your azure devops organization name.

On Test Method  level add test case attribure [janono.ado.testcase.associate.TestCase(1)]


Optionaly add using statment namespace "using janono.ado.testcase.associate" to use shor name for atrributes
[janono.ado.testcase.associate.Organization("janono-pub")] ->  [Organization("janono-pub")]
[janono.ado.testcase.associate.Organization("janono-pub")] ->  [TestCase(1)]


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //yours test method content
            //...
            //
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleTestProject
{
    [TestClass]
    [janono.ado.testcase.associate.Organization("janono-pub")]
    public class UnitTest1
    {
        [TestMethod]
        [janono.ado.testcase.associate.TestCase(1)]
        public void TestMethod1()
        {
            //yours test method content
            //...
            //
        }
    }
}


using Microsoft.VisualStudio.TestTools.UnitTesting;
using janono.ado.testcase.associate;

namespace ExampleTestProject
{
    [TestClass]
    [Organization("janono-pub")]
    public class UnitTest1
    {
        [TestMethod]
        [TestCase(1)]
        public void TestMethod1()
        {
            //yours test method content
            //...
            //
        }
    }
}

you are almoust ready to go, normalny you
would open test exproler from visual studio and then find corepoding test,
then you would connect from Team Explorer to yours Azure DevOps organization,
Then you will query for specitc test case Id for ith oyu would like to assocate or run query to find it.
All that you will repat or update  for each test case for with you have automation.




Add suport from Azure devops server
Add extension to Azure devops Market with dedicated build task for making auomtatic association.




Download latest release from https://github.com/JanuszNowak/janono.ado.testcase.associate.cli/releases for your platform Windwos, MacOs, Linux as cli is writen in cross pltform .NET Core.

Extract to folder where you would like to keep it.
Open console with you are using, go to folder where you extract cli,
Type janono.ado.testcase.associate.cli.exe press enter, now you will see the posible options

Options:
  -am, --authMethod <Basic|oAuth|PAT> (REQUIRED)  Authentication method Oauth Token, PAT,Basic
  --authValue <authValue> (REQUIRED)              The password, Personal Access Token or OAuth Token to authenticate
  --action <Associate|List> (REQUIRED)            Action
  --path <path> (REQUIRED)                        Path to dlls with tests, supporting '*' wildcards.
  --version                                       Show version information
  -?, -h, --help                                  Show help and usage information




