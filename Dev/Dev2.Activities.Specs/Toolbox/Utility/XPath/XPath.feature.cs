
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2014 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18063
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Toolbox.Utility.XPath
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class XPathFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "XPath.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "XPath", "In order to run a query against xml\r\nAs a Warewolf user\r\nI want a tool that I can" +
                    " use to execute xpath queries", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "XPath")))
            {
                Dev2.Activities.Specs.Toolbox.Utility.XPath.XPathFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath to get data off XML - Id = 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathToGetDataOffXML_Id1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath to get data off XML - Id = 1", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I have a variable \"[[firstNum]]\" output with xpath \"//root/number[@id=\'1\']/text()" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("the variable \"[[firstNum]]\" should have a value \"One\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table1.AddRow(new string[] {
                        "<root><number id=\"1\">One</number><number id=\"2\">Two</number><number id=\"3\">Three<" +
                            "/number></root>",
                        "1",
                        "[[firstNum]] = //root/number[@id=\'1\']/text()"});
#line 12
 testRunner.And("the debug inputs as", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table2.AddRow(new string[] {
                        "1",
                        "[[firstNum]] = One"});
#line 15
 testRunner.And("the debug output as", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath to get data off XML - Id = 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathToGetDataOffXML_Id2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath to get data off XML - Id = 2", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And("I have a variable \"[[firstNum]]\" output with xpath \"//root/number[@id=\'2\']/text()" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("the variable \"[[firstNum]]\" should have a value \"Two\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table3.AddRow(new string[] {
                        "<root><number id=\"1\">One</number><number id=\"2\">Two</number><number id=\"3\">Three<" +
                            "/number></root>",
                        "1",
                        "[[firstNum]] = //root/number[@id=\'2\']/text()"});
#line 25
 testRunner.And("the debug inputs as", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table4.AddRow(new string[] {
                        "1",
                        "[[firstNum]] = Two"});
#line 28
 testRunner.And("the debug output as", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath to build a recordset with 2 fields")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathToBuildARecordsetWith2Fields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath to build a recordset with 2 fields", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.And("I have a variable \"[[rec(*).id]]\" output with xpath \"//root/number/@id\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("I have a variable \"[[rec2(*).text]]\" output with xpath \"//root/number/text()\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec().id"});
            table5.AddRow(new string[] {
                        "1"});
            table5.AddRow(new string[] {
                        "2"});
            table5.AddRow(new string[] {
                        "3"});
#line 37
 testRunner.Then("the xpath result for this varibale \"[[rec().id]]\" will be", ((string)(null)), table5, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec().text"});
            table6.AddRow(new string[] {
                        "One"});
            table6.AddRow(new string[] {
                        "Two"});
            table6.AddRow(new string[] {
                        "Three"});
#line 42
 testRunner.Then("the xpath result for this varibale \"[[rec2().text]]\" will be", ((string)(null)), table6, "Then ");
#line 47
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table7.AddRow(new string[] {
                        "<root><number id=\"1\">One</number><number id=\"2\">Two</number><number id=\"3\">Three<" +
                            "/number></root>",
                        "1",
                        "[[rec(*).id]] = //root/number/@id"});
            table7.AddRow(new string[] {
                        "",
                        "2",
                        "[[rec2(*).text]] = //root/number/text()"});
#line 48
 testRunner.And("the debug inputs as", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table8.AddRow(new string[] {
                        "1",
                        "[[rec(1).id]] = 1"});
            table8.AddRow(new string[] {
                        "",
                        "[[rec(2).id]] = 2"});
            table8.AddRow(new string[] {
                        "",
                        "[[rec(3).id]] = 3"});
            table8.AddRow(new string[] {
                        "2",
                        "[[rec2(1).text]] = One"});
            table8.AddRow(new string[] {
                        "",
                        "[[rec2(2).text]] = Two"});
            table8.AddRow(new string[] {
                        "",
                        "[[rec2(3).text]] = Three"});
#line 52
 testRunner.And("the debug output as", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath that does not exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathThatDoesNotExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath that does not exist", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
 testRunner.And("I have a variable \"[[ids]]\" output with xpath \"//root/num/@id\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.Then("the variable \"[[ids]]\" should have a value \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table9.AddRow(new string[] {
                        "<root><number id=\"1\">One</number><number id=\"2\">Two</number><number id=\"3\">Three<" +
                            "/number></root>",
                        "1",
                        "[[ids]] = //root/num/@id"});
#line 67
 testRunner.And("the debug inputs as", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table10.AddRow(new string[] {
                        "1",
                        "[[ids]] ="});
#line 70
 testRunner.And("the debug output as", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use invalid xpath query")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseInvalidXpathQuery()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use invalid xpath query", ((string[])(null)));
#line 74
this.ScenarioSetup(scenarioInfo);
#line 75
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\' in a variable \"[[myxml]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 76
 testRunner.And("I assign the variable \"[[myxml]]\" as xml input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("I have a variable \"[[ids]]\" output with xpath \"@@#$\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
 testRunner.Then("the variable \"[[ids]]\" should have a value \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table11.AddRow(new string[] {
                        "[[myxml]] = <root><number id=\"1\">One</number><number id=\"2\">Two</number><number i" +
                            "d=\"3\">Three</number></root>",
                        "1",
                        "[[ids]] = @@#$"});
#line 81
 testRunner.And("the debug inputs as", ((string)(null)), table11, "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table12.AddRow(new string[] {
                        "1",
                        "[[ids]] ="});
#line 84
 testRunner.And("the debug output as", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath with append notation should add")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathWithAppendNotationShouldAdd()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath with append notation should add", ((string[])(null)));
#line 88
this.ScenarioSetup(scenarioInfo);
#line 89
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\' in a variable \"[[rec().set]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.And("I assign the variable \"[[rec().set]]\" as xml input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("I have a variable \"[[rec().set]]\" output with xpath \"//root/number/@id\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec().set"});
            table13.AddRow(new string[] {
                        "<root><number id=\"1\">One</number><number id=\"2\">Two</number><number id=\"3\">Three<" +
                            "/number></root>"});
            table13.AddRow(new string[] {
                        "1"});
            table13.AddRow(new string[] {
                        "2"});
            table13.AddRow(new string[] {
                        "3"});
#line 93
 testRunner.Then("the xpath result for this varibale \"[[rec().set]]\" will be", ((string)(null)), table13, "Then ");
#line 99
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table14.AddRow(new string[] {
                        "[[rec(1).set]] = <root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                            "ber id=\"3\">Three</number></root>",
                        "1",
                        "[[rec(1).set]] = //root/number/@id"});
#line 100
 testRunner.And("the debug inputs as", ((string)(null)), table14, "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table15.AddRow(new string[] {
                        "1",
                        "[[rec(2).set]] = 1"});
            table15.AddRow(new string[] {
                        "",
                        "[[rec(3).set]] = 2"});
            table15.AddRow(new string[] {
                        "",
                        "[[rec(4).set]] = 3"});
#line 103
 testRunner.And("the debug output as", ((string)(null)), table15, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath with invalid XML as input inside a")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void UseXPathWithInvalidXMLAsInputInsideA()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath with invalid XML as input inside a", new string[] {
                        "ignore"});
#line 112
this.ScenarioSetup(scenarioInfo);
#line 113
 testRunner.Given("I have this xml \'<start></end>\' in a variable \"[[myxml]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 114
 testRunner.And("I assign the variable \"[[myxml]]\" as xml input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("I have a variable \"[[ids]]\" output with xpath \"//root\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
 testRunner.Then("the variable \"[[ids]]\" should have a value \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 118
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        ""});
            table16.AddRow(new string[] {
                        "[[myxml]] = <root></end>",
                        "[[ids]] = //root"});
#line 119
 testRunner.And("the debug inputs as", ((string)(null)), table16, "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table17.AddRow(new string[] {
                        "1",
                        "[[ids]] ="});
#line 122
 testRunner.And("the debug output as", ((string)(null)), table17, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath with no  result but valid xpath")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathWithNoResultButValidXpath()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath with no  result but valid xpath", ((string[])(null)));
#line 126
this.ScenarioSetup(scenarioInfo);
#line 127
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 128
 testRunner.And("I have a variable \"\" output with xpath \"//root/number/@id\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 130
 testRunner.Then("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table18.AddRow(new string[] {
                        "<root><number id=\"1\">One</number><number id=\"2\">Two</number><number id=\"3\">Three<" +
                            "/number></root>",
                        "",
                        ""});
#line 131
 testRunner.And("the debug inputs as", ((string)(null)), table18, "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
#line 134
 testRunner.And("the debug output as", ((string)(null)), table19, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath to get multiple results into a scalar in CSV")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathToGetMultipleResultsIntoAScalarInCSV()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath to get multiple results into a scalar in CSV", ((string[])(null)));
#line 137
this.ScenarioSetup(scenarioInfo);
#line 138
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 139
 testRunner.And("I have a variable \"[[ids]]\" output with xpath \"//root/number/@id\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
 testRunner.Then("the variable \"[[ids]]\" should have a value \"1,2,3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table20.AddRow(new string[] {
                        "<root><number id=\"1\">One</number><number id=\"2\">Two</number><number id=\"3\">Three<" +
                            "/number></root>",
                        "1",
                        "[[ids]] = //root/number/@id"});
#line 143
 testRunner.And("the debug inputs as", ((string)(null)), table20, "And ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table21.AddRow(new string[] {
                        "1",
                        "[[ids]] = 1,2,3"});
#line 146
 testRunner.And("the debug output as", ((string)(null)), table21, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use the XPath to process blank XML")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseTheXPathToProcessBlankXML()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use the XPath to process blank XML", ((string[])(null)));
#line 150
this.ScenarioSetup(scenarioInfo);
#line 151
 testRunner.Given("I have this xml \'\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 152
 testRunner.And("I have a variable \"[[ids]]\" output with xpath \"//root/number/@id\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
 testRunner.Then("the variable \"[[ids]]\" should have a value \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 155
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table22.AddRow(new string[] {
                        "\"\"",
                        "1",
                        "[[ids]] =  //root/number/@id"});
#line 156
 testRunner.And("the debug inputs as", ((string)(null)), table22, "And ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table23.AddRow(new string[] {
                        "1",
                        "[[ids]] ="});
#line 159
 testRunner.And("the debug output as", ((string)(null)), table23, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use the XPath without any xpath query")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseTheXPathWithoutAnyXpathQuery()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use the XPath without any xpath query", ((string[])(null)));
#line 163
this.ScenarioSetup(scenarioInfo);
#line 164
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 165
 testRunner.And("I have a variable \"[[ids]]\" output with xpath \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 167
 testRunner.Then("the variable \"[[ids]]\" should have a value \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 168
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table24.AddRow(new string[] {
                        "<root><number id=\"1\">One</number><number id=\"2\">Two</number><number id=\"3\">Three<" +
                            "/number></root>",
                        "1",
                        "[[ids]] ="});
#line 169
 testRunner.And("the debug inputs as", ((string)(null)), table24, "And ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table25.AddRow(new string[] {
                        "1",
                        "[[ids]] ="});
#line 172
 testRunner.And("the debug output as", ((string)(null)), table25, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath with blank  as XML input")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathWithBlankAsXMLInput()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath with blank  as XML input", ((string[])(null)));
#line 176
this.ScenarioSetup(scenarioInfo);
#line 177
 testRunner.Given("I have this xml \'\' in a variable \"[[myxml]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 178
 testRunner.And("I assign the variable \"[[myxml]]\" as xml input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
 testRunner.And("I have a variable \"[[ids]]\" output with xpath \"//root/num/@id\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 181
 testRunner.Then("the variable \"[[ids]]\" should have a value \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 182
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table26.AddRow(new string[] {
                        "[[myxml]] =",
                        "1",
                        "[[ids]] = //root/num/@id"});
#line 183
 testRunner.And("the debug inputs as", ((string)(null)), table26, "And ");
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table27.AddRow(new string[] {
                        "1",
                        "[[ids]] ="});
#line 186
 testRunner.And("the debug output as", ((string)(null)), table27, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath with negative recordset index as XML input")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathWithNegativeRecordsetIndexAsXMLInput()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath with negative recordset index as XML input", ((string[])(null)));
#line 190
this.ScenarioSetup(scenarioInfo);
#line 191
 testRunner.Given("I have this xml \'<x></b></x>\' in a variable \"[[rec(-1).myxml]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 192
 testRunner.And("I assign the variable \"[[rec(-1).myxml]]\" as xml input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
 testRunner.And("I have a variable \"[[ids]]\" output with xpath \"//b\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 195
 testRunner.Then("the variable \"[[ids]]\" should have a value \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 196
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table28.AddRow(new string[] {
                        "[[rec(-1).myxml]] =",
                        "1",
                        "[[ids]] = //b"});
#line 197
 testRunner.And("the debug inputs as", ((string)(null)), table28, "And ");
#line hidden
            TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table29.AddRow(new string[] {
                        "1",
                        "[[ids]] ="});
#line 200
 testRunner.And("the debug output as", ((string)(null)), table29, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Use XPath with negative recordset index as output")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "XPath")]
        public virtual void UseXPathWithNegativeRecordsetIndexAsOutput()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Use XPath with negative recordset index as output", ((string[])(null)));
#line 204
this.ScenarioSetup(scenarioInfo);
#line 205
 testRunner.Given("I have this xml \'<root><number id=\"1\">One</number><number id=\"2\">Two</number><num" +
                    "ber id=\"3\">Three</number></root>\' in a variable \"[[xml]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 206
 testRunner.And("I assign the variable \"[[xml]]\" as xml input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 207
 testRunner.And("I have a variable \"[[rec(-1).ids]]\" output with xpath \"//root/number[@id=\'2\']/tex" +
                    "t()\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 208
 testRunner.When("the xpath tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 209
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                        "XML",
                        "#",
                        ""});
            table30.AddRow(new string[] {
                        "[[xml]] = <root><number id=\"1\">One</number><number id=\"2\">Two</number><number id=" +
                            "\"3\">Three</number></root>",
                        "1",
                        "[[rec(-1).ids]] = //root/number[@id=\'2\']/text()"});
#line 210
 testRunner.And("the debug inputs as", ((string)(null)), table30, "And ");
#line hidden
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 213
 testRunner.And("the debug output as", ((string)(null)), table31, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
