﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Toolbox._3RdPartyConnectors.Sharepoint
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CreateItemInListFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateItemInList.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CreateItemInList", "In order to add items to a Sharepoint List\nAs a Warewolf user\nI want to a tool th" +
                    "at willl show me what fields need to be captured", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CreateItemInList")))
            {
                Dev2.Activities.Specs.Toolbox._3RdPartyConnectors.Sharepoint.CreateItemInListFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Item static data")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateItemInList")]
        public virtual void CreateItemStaticData()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Item static data", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have a sharepoint source to \"http://rsaklfsvrsharep/\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I select \"AcceptanceTesting\" list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field Name",
                        "Variable"});
            table1.AddRow(new string[] {
                        "Name",
                        "Created From Warewolf"});
            table1.AddRow(new string[] {
                        "Title",
                        "My New Warewolf Acceptance Test Item"});
#line 9
 testRunner.And("I map the list input fields as", ((string)(null)), table1, "And ");
#line 13
 testRunner.And("I have result variable as \"[[Result]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.When("the sharepoint tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("the value of \"[[Result]]\" equals \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Field Name",
                        "Variable"});
            table2.AddRow(new string[] {
                        "1",
                        "Name",
                        "Created From Warewolf"});
            table2.AddRow(new string[] {
                        "2",
                        "Title",
                        "My New Warewolf Acceptance Test Item"});
#line 17
 testRunner.And("the debug inputs as", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table3.AddRow(new string[] {
                        "[[Result]] = Success"});
#line 21
 testRunner.And("the debug output as", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Item scalar data")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateItemInList")]
        public virtual void CreateItemScalarData()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Item scalar data", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given("I have a sharepoint source to \"http://rsaklfsvrsharep/\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.And("I select \"AcceptanceTesting\" list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field Name",
                        "Variable"});
            table4.AddRow(new string[] {
                        "Name",
                        "[[name]]"});
            table4.AddRow(new string[] {
                        "Title",
                        "[[title]]"});
#line 28
 testRunner.And("I map the list input fields as", ((string)(null)), table4, "And ");
#line 32
 testRunner.And("I have result variable as \"[[Result]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I have a variable \"[[name]]\" with value \"Created From Warewolf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("I have a variable \"[[title]]\" with value \"My New Warewolf Acceptance Test Item\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.When("the sharepoint tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.Then("the value of \"[[Result]]\" equals \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Field Name",
                        "Variable"});
            table5.AddRow(new string[] {
                        "1",
                        "Name",
                        "[[name]] = Created From Warewolf"});
            table5.AddRow(new string[] {
                        "2",
                        "Title",
                        "[[title]] = My New Warewolf Acceptance Test Item"});
#line 38
 testRunner.And("the debug inputs as", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table6.AddRow(new string[] {
                        "[[Result]] = Success"});
#line 42
 testRunner.And("the debug output as", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Item recordset last record")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateItemInList")]
        public virtual void CreateItemRecordsetLastRecord()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Item recordset last record", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
 testRunner.Given("I have a sharepoint source to \"http://rsaklfsvrsharep/\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.And("I select \"AcceptanceTesting\" list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field Name",
                        "Variable"});
            table7.AddRow(new string[] {
                        "Name",
                        "[[items().name]]"});
            table7.AddRow(new string[] {
                        "Title",
                        "[[items().title]]"});
#line 49
 testRunner.And("I map the list input fields as", ((string)(null)), table7, "And ");
#line 53
 testRunner.And("I have result variable as \"[[Result]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("I have a variable \"[[items().name]]\" with value \"Created From Warewolf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("I have a variable \"[[items().title]]\" with value \"My New Warewolf Acceptance Test" +
                    " Item\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.When("the sharepoint tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.Then("the value of \"[[Result]]\" equals \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Field Name",
                        "Variable"});
            table8.AddRow(new string[] {
                        "1",
                        "Name",
                        "[[items(1).name]] = Created From Warewolf"});
            table8.AddRow(new string[] {
                        "2",
                        "Title",
                        "[[items(1).title]] = My New Warewolf Acceptance Test Item"});
#line 59
 testRunner.And("the debug inputs as", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table9.AddRow(new string[] {
                        "[[Result]] = Success"});
#line 63
 testRunner.And("the debug output as", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Item recordset given record index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateItemInList")]
        public virtual void CreateItemRecordsetGivenRecordIndex()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Item recordset given record index", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given("I have a sharepoint source to \"http://rsaklfsvrsharep/\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
 testRunner.And("I select \"AcceptanceTesting\" list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field Name",
                        "Variable"});
            table10.AddRow(new string[] {
                        "Name",
                        "[[items(1).name]]"});
            table10.AddRow(new string[] {
                        "Title",
                        "[[items(1).title]]"});
#line 70
 testRunner.And("I map the list input fields as", ((string)(null)), table10, "And ");
#line 74
 testRunner.And("I have result variable as \"[[Result]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("I have a variable \"[[items().name]]\" with value \"Created From Warewolf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I have a variable \"[[items().title]]\" with value \"My New Warewolf Acceptance Test" +
                    " Item\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.When("the sharepoint tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.Then("the value of \"[[Result]]\" equals \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Field Name",
                        "Variable"});
            table11.AddRow(new string[] {
                        "1",
                        "Name",
                        "[[items(1).name]] = Created From Warewolf"});
            table11.AddRow(new string[] {
                        "2",
                        "Title",
                        "[[items(1).title]] = My New Warewolf Acceptance Test Item"});
#line 80
 testRunner.And("the debug inputs as", ((string)(null)), table11, "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table12.AddRow(new string[] {
                        "[[Result]] = Success"});
#line 84
 testRunner.And("the debug output as", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Item recordset all records")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CreateItemInList")]
        public virtual void CreateItemRecordsetAllRecords()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Item recordset all records", ((string[])(null)));
#line 88
this.ScenarioSetup(scenarioInfo);
#line 89
 testRunner.Given("I have a sharepoint source to \"http://rsaklfsvrsharep/\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.And("I select \"AcceptanceTesting\" list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field Name",
                        "Variable"});
            table13.AddRow(new string[] {
                        "Name",
                        "[[items(*).name]]"});
            table13.AddRow(new string[] {
                        "Title",
                        "[[items(*).title]]"});
#line 91
 testRunner.And("I map the list input fields as", ((string)(null)), table13, "And ");
#line 95
 testRunner.And("I have result variable as \"[[Result]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("I have a variable \"[[items().name]]\" with value \"Created From Warewolf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("I have a variable \"[[items().title]]\" with value \"My New Warewolf Acceptance Test" +
                    " Item\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("I have a variable \"[[items().name]]\" with value \"Created From Warewolf 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I have a variable \"[[items().title]]\" with value \"My New Warewolf Acceptance Test" +
                    " Item 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.When("the sharepoint tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
 testRunner.Then("the value of \"[[Result]]\" equals \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Field Name",
                        "Variable"});
            table14.AddRow(new string[] {
                        "1",
                        "Name",
                        "[[items(1).name]] = Created From Warewolf"});
            table14.AddRow(new string[] {
                        "",
                        "Name",
                        "[[items(2).name]] = Created From Warewolf 2"});
            table14.AddRow(new string[] {
                        "2",
                        "Title",
                        "[[items(1).title]] = My New Warewolf Acceptance Test Item"});
            table14.AddRow(new string[] {
                        "",
                        "Title",
                        "[[items(2).title]] = My New Warewolf Acceptance Test Item 2"});
#line 103
 testRunner.And("the debug inputs as", ((string)(null)), table14, "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table15.AddRow(new string[] {
                        "[[Result]] = Success"});
#line 109
 testRunner.And("the debug output as", ((string)(null)), table15, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
