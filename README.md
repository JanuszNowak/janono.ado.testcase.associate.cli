# janono.ado.testcase.associate.cli
 janono.ado.testcase.associate.cli
 [![Build Status](https://dev.azure.com/janono-pub/Janono.Ado.TestCase.Associate/_apis/build/status/janono.ado.testcase.associate.cli-ci?branchName=master)](https://dev.azure.com/janono-pub/Janono.Ado.TestCase.Associate/_build/latest?definitionId=34&branchName=master)

janono.ado.testcase.associate is an extension for automatic association of test methods from code to [Test Cases](https://docs.microsoft.com/en-us/azure/devops/test/create-a-test-plan?view=azure-devops) in [Azure DevOps](https://azure.microsoft.com/en-us/services/devops/) [Test Plans](https://azure.microsoft.com/en-us/services/devops/test-plans/).

Extension was created as current aproach for association is [manual activity](https://docs.microsoft.com/en-us/azure/devops/test/associate-automated-test-with-test-case?view=azure-devops) activty for each test case with can be very time consuming, susceptible to mistakes (as each manual activity), time costly in maintenance. Current aporach also requires [Visual Studio](https://visualstudio.microsoft.com/pl/) with is not needed in case of using extension.

Extension consists of 2 components
* [Nuget package](https://www.nuget.org/packages/janono.ado.testcase.associate/) [janono.ado.testcase.associate](https://github.com/JanuszNowak/janono.ado.testcase.associate) that containse decoration attribute, to mark test and organization [![NuGet](https://img.shields.io/nuget/v/janono.ado.testcase.associate.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/janono.ado.testcase.associate/) 
* CLI that is executing actions like assocation [janono.ado.testcase.associate.cli](https://github.com/JanuszNowak/janono.ado.testcase.associate.cli)

![janono.ado.testcase.associate](/img/end2.png)


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




## Getting started

* Create Test Porject or open existing, supported any with [MSTest](https://github.com/microsoft/testfx), [NUnit](https://nunit.org/), [xUnit](https://github.com/xunit/xunit) writen in [.NET Core](https://github.com/dotnet/core) or [.NET Framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework) version.

* Add latest nuget package "janono.ado.testcase.associate" from https://www.nuget.org/packages/janono.ado.testcase.associate/ [![NuGet](https://img.shields.io/nuget/v/janono.ado.testcase.associate.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/janono.ado.testcase.associate/).

<!-- ![janono.ado.testcase.associate](/img/5_add_nuget.png) -->


* On Test Class level add organization atrribute ```[janono.ado.testcase.associate.Organization("janono-pub")]``` where replace value "janono-pub" your azure devops organization name.

```cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleTestProject
{
    [TestClass]
    [janono.ado.testcase.associate.Organization("janono-pub")] //<---
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
```


* On Test Method  level add test case attribure ```[janono.ado.testcase.associate.TestCase(5)]```  where repalce '5' with yours 'test case id' for with you want to assocate automation.

```cs
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleTestProject
{
    [TestClass]
    [janono.ado.testcase.associate.Organization("janono-pub")]
    public class UnitTest1
    {
        [TestMethod]
        [janono.ado.testcase.associate.TestCase(5)] //<---
        public void TestMethod1()
        {
            //yours test method content
            //...
            //
        }
    }
}
```

* Optionaly add using statment namespace "using janono.ado.testcase.associate" to use shor name for atrributes
```[janono.ado.testcase.associate.Organization("janono-pub")] ->  [Organization("janono-pub")]```
```[janono.ado.testcase.associate.Organization("janono-pub")] ->  [TestCase(5)]```
```cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using janono.ado.testcase.associate; //<---

namespace ExampleTestProject
{
    [TestClass]
    [Organization("janono-pub")] //<---
    public class UnitTest1
    {
        [TestMethod]
        [TestCase(5)] //<---
        public void TestMethod1()
        {
            //yours test method content
            //...
            //
        }
    }
}
```
* Build projects or solution for generating ddl assemby for tests

* Download latest CLI release [janono.ado.testcase.associate.cli](https://github.com/JanuszNowak/janono.ado.testcase.associate.cli/releases) for your platform Windwos, MacOs, [Linux](https://en.wikipedia.org/wiki/Linux) as cli is writen in cross pltform [.NET Core](https://github.com/dotnet/core). Extract to folder where you would like to keep it.

* Open console with you are using, go to folder where you extract cli. Type "janono.ado.testcase.associate.cli.exe" press enter, now you will see the posible options.
![janono.ado.testcase.associate](/img/cli.png)

```
    Options:
    -am, --authMethod <Basic|oAuth|PAT> (REQUIRED)  Authentication method Oauth Token, PAT,Basic
    --authValue <authValue> (REQUIRED)              The password, Personal Access Token or OAuth Token to authenticate
    --action <Associate|List> (REQUIRED)            Action
    --path <path> (REQUIRED)                        Path to dlls with tests, supporting '*' wildcards.
    --version                                       Show version information
    -?, -h, --help                                  Show help and usage information
```

* Pass parameters for CLI
    * --authMethod PAT or oAuth(in comming future)
    * --authMethod "PAT" [PAT (personal access token)](https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate)
    * --path to dll file with test for association
    * --action "List" for scan dll test assembly and check if need to update assocication, or "Associate" for association test medthods to test cases also cover update case

* Example --action "List" ```janono.ado.testcase.associate.cli.exe --authMethod PAT --authValue [yours PAT] --path D:\ExampleTestProject\bin\Release\net6.0\ExampleTestProject.dll --action List```
![janono.ado.testcase.associate](/img/cli_List.png)

* Example --action "Associate" ```janono.ado.testcase.associate.cli.exe --authMethod PAT --authValue [yours PAT] --path D:\ExampleTestProject\bin\Release\net6.0\ExampleTestProject.dll --action Associate```
![janono.ado.testcase.associate](/img/cli_Associate.png)

* Result, now on test case workitem on "Associated Automation" tab you will see automatically associated automation with will be executed [run automated tests from test plans](https://docs.microsoft.com/en-us/azure/devops/test/run-automated-tests-from-test-hub?view=azure-devops).
![janono.ado.testcase.associate](/img/end_result.png)

<!-- normalny you
would open test exproler from visual studio and then find corepoding test,
then you would connect from Team Explorer to yours Azure DevOps organization,
Then you will query for specitc test case Id for ith oyu would like to assocate or run query to find it.
All that you will repat or update  for each test case for with you have automation.  -->

## Features planned
* Add support for for [Azure devops server](https://azure.microsoft.com/pl-pl/services/devops/server/).
* Add [Azure DevOps Marketplace](https://marketplace.visualstudio.com/) extension with dedicated build task for making automatic association.
* Generate CLI for multiple platforms.


## Communication
[Gitter](https://gitter.im/JanuszNowak/janono.ado.testcase.associate)
