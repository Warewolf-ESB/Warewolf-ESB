
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
namespace Dev2.Activities.Specs.Toolbox.Recordset.Sort
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SortFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Sort.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Sort", "In order to sort a recordset\r\nAs a Warewolf user\r\nI want a tool I can use to arra" +
                    "nge records in either ascending or descending order", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Sort")))
            {
                Dev2.Activities.Specs.Toolbox.Recordset.Sort.SortFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort a recordset forwards using star notation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortARecordsetForwardsUsingStarNotation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort a recordset forwards using star notation", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "You"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "are"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "the"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "best"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "user"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "so far"});
#line 7
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table1, "Given ");
#line 16
 testRunner.And("I sort a record \"[[rs(*).row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("my sort order is \"Forward\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "are"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "best"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "so far"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "the"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "user"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "You"});
#line 19
 testRunner.Then("the sorted recordset \"[[rs().row]]\"  will be", ((string)(null)), table2, "Then ");
#line 28
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table3.AddRow(new string[] {
                        "[[rs(1).row]] = You",
                        ""});
            table3.AddRow(new string[] {
                        "[[rs(2).row]] = are",
                        ""});
            table3.AddRow(new string[] {
                        "[[rs(3).row]] = the",
                        ""});
            table3.AddRow(new string[] {
                        "[[rs(4).row]] = best",
                        ""});
            table3.AddRow(new string[] {
                        "[[rs(5).row]] = Warewolf",
                        ""});
            table3.AddRow(new string[] {
                        "[[rs(6).row]] = user",
                        ""});
            table3.AddRow(new string[] {
                        "[[rs(7).row]] = so far",
                        "Forward"});
#line 29
 testRunner.And("the debug inputs as", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table4.AddRow(new string[] {
                        "[[rs(1).row]] = are"});
            table4.AddRow(new string[] {
                        "[[rs(2).row]] = best"});
            table4.AddRow(new string[] {
                        "[[rs(3).row]] = so far"});
            table4.AddRow(new string[] {
                        "[[rs(4).row]] = the"});
            table4.AddRow(new string[] {
                        "[[rs(5).row]] = user"});
            table4.AddRow(new string[] {
                        "[[rs(6).row]] = Warewolf"});
            table4.AddRow(new string[] {
                        "[[rs(7).row]] = You"});
#line 38
 testRunner.And("the debug output as", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort a recordset backwards using star notation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortARecordsetBackwardsUsingStarNotation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort a recordset backwards using star notation", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "You"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "are"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "the"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "best"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "user"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "so far"});
#line 49
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table5, "Given ");
#line 58
 testRunner.And("I sort a record \"[[rs(*).row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("my sort order is \"Backwards\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "You"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "user"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "the"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "so far"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "best"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "are"});
#line 61
 testRunner.Then("the sorted recordset \"[[rs().row]]\"  will be", ((string)(null)), table6, "Then ");
#line 70
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table7.AddRow(new string[] {
                        "[[rs(1).row]] = You",
                        ""});
            table7.AddRow(new string[] {
                        "[[rs(2).row]] = are",
                        ""});
            table7.AddRow(new string[] {
                        "[[rs(3).row]] = the",
                        ""});
            table7.AddRow(new string[] {
                        "[[rs(4).row]] = best",
                        ""});
            table7.AddRow(new string[] {
                        "[[rs(5).row]] = Warewolf",
                        ""});
            table7.AddRow(new string[] {
                        "[[rs(6).row]] = user",
                        ""});
            table7.AddRow(new string[] {
                        "[[rs(7).row]] = so far",
                        "Backwards"});
#line 71
 testRunner.And("the debug inputs as", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table8.AddRow(new string[] {
                        "[[rs(1).row]] = You"});
            table8.AddRow(new string[] {
                        "[[rs(2).row]] = Warewolf"});
            table8.AddRow(new string[] {
                        "[[rs(3).row]] = user"});
            table8.AddRow(new string[] {
                        "[[rs(4).row]] = the"});
            table8.AddRow(new string[] {
                        "[[rs(5).row]] = so far"});
            table8.AddRow(new string[] {
                        "[[rs(6).row]] = best"});
            table8.AddRow(new string[] {
                        "[[rs(7).row]] = are"});
#line 80
 testRunner.And("the debug output as", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort a recordset forwards")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortARecordsetForwards()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort a recordset forwards", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "You"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "are"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "the"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "best"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "user"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "so far"});
#line 91
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table9, "Given ");
#line 100
 testRunner.And("I sort a record \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("my sort order is \"Forward\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table10.AddRow(new string[] {
                        "rs().row",
                        "are"});
            table10.AddRow(new string[] {
                        "rs().row",
                        "best"});
            table10.AddRow(new string[] {
                        "rs().row",
                        "so far"});
            table10.AddRow(new string[] {
                        "rs().row",
                        "the"});
            table10.AddRow(new string[] {
                        "rs().row",
                        "user"});
            table10.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
            table10.AddRow(new string[] {
                        "rs().row",
                        "You"});
#line 103
 testRunner.Then("the sorted recordset \"[[rs().row]]\"  will be", ((string)(null)), table10, "Then ");
#line 112
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table11.AddRow(new string[] {
                        "[[rs(1).row]] = You",
                        ""});
            table11.AddRow(new string[] {
                        "[[rs(2).row]] = are",
                        ""});
            table11.AddRow(new string[] {
                        "[[rs(3).row]] = the",
                        ""});
            table11.AddRow(new string[] {
                        "[[rs(4).row]] = best",
                        ""});
            table11.AddRow(new string[] {
                        "[[rs(5).row]] = Warewolf",
                        ""});
            table11.AddRow(new string[] {
                        "[[rs(6).row]] = user",
                        ""});
            table11.AddRow(new string[] {
                        "[[rs(7).row]] = so far",
                        "Forward"});
#line 113
 testRunner.And("the debug inputs as", ((string)(null)), table11, "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table12.AddRow(new string[] {
                        "[[rs(1).row]] = are"});
            table12.AddRow(new string[] {
                        "[[rs(2).row]] = best"});
            table12.AddRow(new string[] {
                        "[[rs(3).row]] = so far"});
            table12.AddRow(new string[] {
                        "[[rs(4).row]] = the"});
            table12.AddRow(new string[] {
                        "[[rs(5).row]] = user"});
            table12.AddRow(new string[] {
                        "[[rs(6).row]] = Warewolf"});
            table12.AddRow(new string[] {
                        "[[rs(7).row]] = You"});
#line 122
 testRunner.And("the debug output as", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort a recordset backwards")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortARecordsetBackwards()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort a recordset backwards", ((string[])(null)));
#line 132
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "You"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "are"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "the"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "best"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "user"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "so far"});
#line 133
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table13, "Given ");
#line 142
 testRunner.And("I sort a record \"[[rs(*).row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
 testRunner.And("my sort order is \"Backwards\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 144
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table14.AddRow(new string[] {
                        "rs().row",
                        "You"});
            table14.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
            table14.AddRow(new string[] {
                        "rs().row",
                        "user"});
            table14.AddRow(new string[] {
                        "rs().row",
                        "the"});
            table14.AddRow(new string[] {
                        "rs().row",
                        "so far"});
            table14.AddRow(new string[] {
                        "rs().row",
                        "best"});
            table14.AddRow(new string[] {
                        "rs().row",
                        "are"});
#line 145
 testRunner.Then("the sorted recordset \"[[rs().row]]\"  will be", ((string)(null)), table14, "Then ");
#line 154
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table15.AddRow(new string[] {
                        "[[rs(1).row]] = You",
                        ""});
            table15.AddRow(new string[] {
                        "[[rs(2).row]] = are",
                        ""});
            table15.AddRow(new string[] {
                        "[[rs(3).row]] = the",
                        ""});
            table15.AddRow(new string[] {
                        "[[rs(4).row]] = best",
                        ""});
            table15.AddRow(new string[] {
                        "[[rs(5).row]] = Warewolf",
                        ""});
            table15.AddRow(new string[] {
                        "[[rs(6).row]] = user",
                        ""});
            table15.AddRow(new string[] {
                        "[[rs(7).row]] = so far",
                        "Backwards"});
#line 155
 testRunner.And("the debug inputs as", ((string)(null)), table15, "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table16.AddRow(new string[] {
                        "[[rs(1).row]] = You"});
            table16.AddRow(new string[] {
                        "[[rs(2).row]] = Warewolf"});
            table16.AddRow(new string[] {
                        "[[rs(3).row]] = user"});
            table16.AddRow(new string[] {
                        "[[rs(4).row]] = the"});
            table16.AddRow(new string[] {
                        "[[rs(5).row]] = so far"});
            table16.AddRow(new string[] {
                        "[[rs(6).row]] = best"});
            table16.AddRow(new string[] {
                        "[[rs(7).row]] = are"});
#line 164
 testRunner.And("the debug output as", ((string)(null)), table16, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort a recordset forwards empty recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortARecordsetForwardsEmptyRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort a recordset forwards empty recordset", ((string[])(null)));
#line 174
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
#line 175
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table17, "Given ");
#line 177
 testRunner.And("I sort a record \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
 testRunner.And("my sort order is \"Forward\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
#line 180
 testRunner.Then("the sorted recordset \"[[rs().row]]\"  will be", ((string)(null)), table18, "Then ");
#line 182
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table19.AddRow(new string[] {
                        "[[rs(*).row]] =",
                        "Forward"});
#line 183
 testRunner.And("the debug inputs as", ((string)(null)), table19, "And ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table20.AddRow(new string[] {
                        ""});
#line 186
 testRunner.And("the debug output as", ((string)(null)), table20, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort a recordset backwards empty recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortARecordsetBackwardsEmptyRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort a recordset backwards empty recordset", ((string[])(null)));
#line 190
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
#line 191
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table21, "Given ");
#line 193
 testRunner.And("I sort a record \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
 testRunner.And("my sort order is \"Backwards\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 195
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
#line 196
 testRunner.Then("the sorted recordset \"[[rs().row]]\"  will be", ((string)(null)), table22, "Then ");
#line 198
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table23.AddRow(new string[] {
                        "[[rs(*).row]] =",
                        "Backwards"});
#line 199
 testRunner.And("the debug inputs as", ((string)(null)), table23, "And ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table24.AddRow(new string[] {
                        "[[rs(*).row]] ="});
#line 202
 testRunner.And("the debug output as", ((string)(null)), table24, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort a recordset forwards with one row")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortARecordsetForwardsWithOneRow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort a recordset forwards with one row", ((string[])(null)));
#line 206
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table25.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
#line 207
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table25, "Given ");
#line 210
 testRunner.And("I sort a record \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 211
 testRunner.And("my sort order is \"Forward\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 212
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table26.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
#line 213
 testRunner.Then("the sorted recordset \"[[rs().row]]\"  will be", ((string)(null)), table26, "Then ");
#line 216
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table27.AddRow(new string[] {
                        "[[rs(1).row]] = Warewolf",
                        "Forward"});
#line 217
 testRunner.And("the debug inputs as", ((string)(null)), table27, "And ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table28.AddRow(new string[] {
                        "[[rs(1).row]] = Warewolf"});
#line 220
 testRunner.And("the debug output as", ((string)(null)), table28, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort a recordset backwards recordset  with one row")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortARecordsetBackwardsRecordsetWithOneRow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort a recordset backwards recordset  with one row", ((string[])(null)));
#line 224
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table29.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
#line 225
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table29, "Given ");
#line 228
 testRunner.And("I sort a record \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 229
 testRunner.And("my sort order is \"Backwards\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 230
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table30.AddRow(new string[] {
                        "rs().row",
                        "Warewolf"});
#line 231
 testRunner.Then("the sorted recordset \"[[rs().row]]\"  will be", ((string)(null)), table30, "Then ");
#line 234
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table31.AddRow(new string[] {
                        "[[rs(1).row]] = Warewolf",
                        "Backwards"});
#line 235
 testRunner.And("the debug inputs as", ((string)(null)), table31, "And ");
#line hidden
            TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table32.AddRow(new string[] {
                        "[[rs(1).row]] = Warewolf"});
#line 238
 testRunner.And("the debug output as", ((string)(null)), table32, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort Recordset without field Forwards")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortRecordsetWithoutFieldForwards()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort Recordset without field Forwards", ((string[])(null)));
#line 281
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table33.AddRow(new string[] {
                        "rs(1).a",
                        "Zambia"});
            table33.AddRow(new string[] {
                        "rec(1).a",
                        "Mangolia"});
            table33.AddRow(new string[] {
                        "rs(2).a",
                        "America"});
            table33.AddRow(new string[] {
                        "rec(2).a",
                        "Australia"});
#line 282
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table33, "Given ");
#line 288
 testRunner.And("I sort a record \"[[rs(*)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 289
 testRunner.And("my sort order is \"Forward\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 290
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 291
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table34.AddRow(new string[] {
                        "[[rs(1).a]] = Zambia",
                        ""});
            table34.AddRow(new string[] {
                        "[[rs(2).a]] = America",
                        "Forward"});
#line 292
 testRunner.And("the debug inputs as", ((string)(null)), table34, "And ");
#line hidden
            TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 296
 testRunner.And("the debug output as", ((string)(null)), table35, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sort Recordset without field Backwards")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sort")]
        public virtual void SortRecordsetWithoutFieldBackwards()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sort Recordset without field Backwards", ((string[])(null)));
#line 299
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "value"});
            table36.AddRow(new string[] {
                        "rs(1).a",
                        "Zambia"});
            table36.AddRow(new string[] {
                        "rec(1).a",
                        "Mangolia"});
            table36.AddRow(new string[] {
                        "rs(2).a",
                        "America"});
            table36.AddRow(new string[] {
                        "rec(2).a",
                        "Australia"});
#line 300
 testRunner.Given("I have the following recordset to sort", ((string)(null)), table36, "Given ");
#line 306
 testRunner.And("I sort a record \"[[rs(*)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 307
 testRunner.And("my sort order is \"Backwards\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 308
 testRunner.When("the sort records tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 309
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                        "Sort Field",
                        "Sort Order"});
            table37.AddRow(new string[] {
                        "[[rs(1).a]] = Zambia",
                        ""});
            table37.AddRow(new string[] {
                        "[[rs(2).a]] = America",
                        "Backwards"});
#line 310
 testRunner.And("the debug inputs as", ((string)(null)), table37, "And ");
#line hidden
            TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 314
 testRunner.And("the debug output as", ((string)(null)), table38, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
