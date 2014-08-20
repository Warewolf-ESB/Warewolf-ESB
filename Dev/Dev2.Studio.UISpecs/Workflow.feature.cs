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
namespace Dev2.Studio.UI.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class WorkflowFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Workflow", "In order to be able to use warewolf\r\nAs a warewolf user\r\nI want to be able to cre" +
                    "ate and execute a workflow", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Workflow")))
            {
                Dev2.Studio.UI.Specs.WorkflowFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Correcting errors on sql bulk insert clicking Done shows small view (using ids)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void CorrectingErrorsOnSqlBulkInsertClickingDoneShowsSmallViewUsingIds()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Correcting errors on sql bulk insert clicking Done shows small view (using ids)", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I click \"UI_RibbonHomeTabWorkflowBtn_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.When("I send \"Sql Bulk Insert\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.And("I drag \"TOOLBOX,PART_Tools,Recordset,Dev2.Activities.DsfSqlBulkInsertActivity\" on" +
                    "to \"WORKSURFACE,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I double click \"UNSAVED1,SQL Bulk Insert(SqlBulkInsertDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I click \"UNSAVED1,SQL Bulk Insert(SqlBulkInsertDesigner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.Then("\"UNSAVED1,A database must be selected.\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.Then("I click \"UNSAVED1,SQL Bulk Insert(SqlBulkInsertDesigner),LargeViewContent,UI__Dat" +
                    "abase_AutoID,GetCities\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And("I click \"UNSAVED1,SQL Bulk Insert(SqlBulkInsertDesigner),LargeViewContent,UI__Tab" +
                    "leName_AutoID,dbo.City\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I click \"UNSAVED1,SQL Bulk Insert(SqlBulkInsertDesigner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.Then("\"UNSAVED1,A database must be selected.\" is not visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Debug GatherSystemInformation same variables in two activites")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DebugGatherSystemInformationSameVariablesInTwoActivites()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Debug GatherSystemInformation same variables in two activites", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And("I send \"11330_Integration tests\" to \"EXPLORER,FilterTextBox,UI_DataListSearchtxt_" +
                    "AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I double click \"EXPLORER,Navigation,UI_localhost,UI_SPINT 7_AutoID,UI_11330_Integ" +
                    "ration tests_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I wait till \"WORKSURFACE\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I wait till \"DEBUGOUTPUT,Dev2StatusBarAutomationID,StatusBar\" is not visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.Then("\"DEBUGOUTPUT,DebugOutputTree,Gather System Info 1 (2),Date & Time\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.Then("\"DEBUGOUTPUT,DebugOutputTree,Gather System Info 1 (2),CPU Available\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.Then("\"DEBUGOUTPUT,DebugOutputTree,Gather System Info 2 (2),Date & Time\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.Then("\"DEBUGOUTPUT,DebugOutputTree,Gather System Info 2 (2),CPU Available\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag on Multiassign")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DragOnMultiassign()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag on Multiassign", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
 testRunner.And("I click \"UI_RibbonHomeTabWorkflowBtn_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.When("I send \"Assign\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.And("I drag \"TOOLMULTIASSIGN\" onto \"ACTIVETAB,Dev2.Studio.ViewModels.WorkSurface.WorkS" +
                    "urfaceContextViewModel,WorkflowDesignerView,UserControl_1,scrollViewer,ActivityT" +
                    "ypeDesigner,WorkflowItemPresenter,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("I send \"[[rec().a]]\" to \"ACTIVETAB,Assign (1)(MultiAssignDesigner),SmallViewConte" +
                    "nt,SmallDataGrid,Unlimited.Applications.BusinessDesignStudio.Activities.Activity" +
                    "DTO,Column Display Index: 1,UI__Row1_FieldName_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I send \"test\" to \"UNSAVED1,Assign (1)(MultiAssignDesigner),SmallViewContent,Small" +
                    "DataGrid,Unlimited.Applications.BusinessDesignStudio.Activities.ActivityDTO,Colu" +
                    "mn Display Index: 1,UI__Row1_FieldValue_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag on BaseCovert")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DragOnBaseCovert()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag on BaseCovert", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.And("I click new \"Workflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.When("I send \"Base\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.And("I drag \"TOOLBASECONVERT\" onto \"WORKSURFACE,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("I double click \"WORKSURFACE,BaseConvert (1)(DsfBaseConvertActivity)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I send \"[[rec().a]]\" to \"WORKSURFACE,BaseConvert (1)(BaseConvertDesigner),SmallVi" +
                    "ewContent,SmallDataGrid,Unlimited.Applications.BusinessDesignStudio.Activities.A" +
                    "ctivityDTO,Column Display Index: 1,UI__Row1_FieldName_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("close the Studio and Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void Drag()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
    testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
    testRunner.Given("I click new \"Workflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
 testRunner.And("I send \"Data Merge\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.When("I drag \"UI_DocManager_AutoID,Zc30a7af8e0c54bb5bccfbea116f8ab0d,Zf1166e575b5d43bb8" +
                    "9f15f346eccb7b1,UI_ToolboxPane_AutoID,UI_ToolboxControl_AutoID,PART_Tools,Data,D" +
                    "sfDataMergeActivity\" onto \"WORKSURFACE,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
    testRunner.And("I double click \"WORKSURFACE,Data Merge (1)(DataMergeDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
    testRunner.And("I send \"Test\" to \"WORKSURFACE,Data Merge (1)(DataMergeDesigner),LargeViewContent," +
                    "LargeDataGrid,Unlimited.Applications.BusinessDesignStudio.Activities.DataMergeDT" +
                    "O,Column Display Index: 1,UI__Row1_InputVariable_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("I send \"%\" to \"WORKSURFACE,Data Merge (1)(DataMergeDesigner),LargeViewContent,Lar" +
                    "geDataGrid,Unlimited.Applications.BusinessDesignStudio.Activities.DataMergeDTO,C" +
                    "olumn Display Index: 3,UI__At_Row1_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I click \"WORKSURFACE,Data Merge (1)(DataMergeDesigner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("I click \"WORKSURFACE,Data Merge (1)(DataMergeDesigner),\'Using\' must be a real num" +
                    "ber\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("I send \"1\" to \"WORKSURFACE,Data Merge (1)(DataMergeDesigner),LargeViewContent,Lar" +
                    "geDataGrid,Unlimited.Applications.BusinessDesignStudio.Activities.DataMergeDTO,C" +
                    "olumn Display Index: 3,UI__At_Row1_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("I click \"WORKSURFACE,Data Merge (1)(DataMergeDesigner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.Given("I send \"%\" to \"WORKSURFACE,Data Merge (1)(DataMergeDesigner),LargeViewContent,Lar" +
                    "geDataGrid,Unlimited.Applications.BusinessDesignStudio.Activities.DataMergeDTO,d" +
                    "ataitem,Column Display Index: 3,UI__At_Row1_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag Assign")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DragAssign()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag Assign", ((string[])(null)));
#line 65
this.ScenarioSetup(scenarioInfo);
#line 67
 testRunner.Given("I click \"UI_RibbonHomeTabWorkflowBtn_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 68
 testRunner.And("I send \"Assign\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.When("I drag \"TOOLMULTIASSIGN\" onto \"ACTIVETAB,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.And("I send \"{TAB} {TAB} {TAB} {TAB} {TAB} {TAB} Test\" to \"ACTIVETAB,Assign (1)(MultiA" +
                    "ssignDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag Data Merge")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DragDataMerge()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag Data Merge", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 92
 testRunner.Given("I click new \"Workflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
 testRunner.And("I send \"Data Merge\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.When(@"I drag ""TOOLBOX,PART_Tools,Data,Unlimited.Applications.BusinessDesignStudio.Activities.DsfDataMergeActivity"" onto ""ACTIVETAB,Dev2.Studio.ViewModels.WorkSurface.WorkSurfaceContextViewModel,UI_WorkflowDesigner_AutoID,UserControl_1,scrollViewer,ActivityTypeDesigner,WorkflowItemPresenter,StartSymbol""", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
 testRunner.And("I send \"Assign\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.When(@"I drag ""TOOLBOX,PART_Tools,Data,Unlimited.Applications.BusinessDesignStudio.Activities.DsfMultiAssignActivity"" onto ""ACTIVETAB,Dev2.Studio.ViewModels.WorkSurface.WorkSurfaceContextViewModel,UI_WorkflowDesigner_AutoID,UserControl_1,scrollViewer,ActivityTypeDesigner,WorkflowItemPresenter,Data Merge (1)(DataMergeDesigner)""", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag Data DataSplit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DragDataDataSplit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag Data DataSplit", ((string[])(null)));
#line 99
this.ScenarioSetup(scenarioInfo);
#line 101
 testRunner.Given("I click new \"Workflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 102
 testRunner.And("I send \"Data Split\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.When(@"I drag ""TOOLBOX,PART_Tools,Data,Unlimited.Applications.BusinessDesignStudio.Activities.DsfDataSplitActivity"" onto ""ACTIVETAB,Dev2.Studio.ViewModels.WorkSurface.WorkSurfaceContextViewModel,UI_WorkflowDesigner_AutoID,UserControl_1,scrollViewer,ActivityTypeDesigner,WorkflowItemPresenter,StartSymbol""", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag Find Record Index")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DragFindRecordIndex()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag Find Record Index", ((string[])(null)));
#line 106
this.ScenarioSetup(scenarioInfo);
#line 110
 testRunner.Given("I click \"UI_RibbonHomeTabWorkflowBtn_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
 testRunner.And("I send \"Data Merge\" to \"TOOLBOXSEARCH\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.When("I drag \"TOOLDATAMERGE\" onto \"ACTIVETAB,Dev2.Studio.ViewModels.WorkSurface.WorkSur" +
                    "faceContextViewModel,UI_WorkflowDesigner_AutoID,UserControl_1,scrollViewer,Activ" +
                    "ityTypeDesigner,WorkflowItemPresenter,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
