﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Composition
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WorkflowResumeFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "WorkflowResume.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WorkflowResume", "\tWhen a workflow execution is suspended\r\n\tI want to Resume", ProgrammingLanguage.CSharp, ((string[])(null)));
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
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WorkflowResume")))
            {
                global::Dev2.Activities.Specs.Composition.WorkflowResumeFeature.FeatureSetup(null);
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
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("When Resuming a Workflow it will always resume from the latest Version")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkflowResume")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ResumeWorkflowExecution")]
        public virtual void WhenResumingAWorkflowItWillAlwaysResumeFromTheLatestVersion()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When Resuming a Workflow it will always resume from the latest Version", new string[] {
                        "ResumeWorkflowExecution"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have a workflow \"ResumeWorkflowFromVersion\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table597 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table597.AddRow(new string[] {
                        "[[rec().a]]",
                        "New"});
            table597.AddRow(new string[] {
                        "[[rec().a]]",
                        "Test"});
#line 8
 testRunner.And("\"ResumeWorkflowFromVersion\" contains an Assign \"VarsAssign\" as", ((string)(null)), table597, "And ");
#line 12
 testRunner.When("workflow \"ResumeWorkflowFromVersion\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.And("Resource \"ResumeWorkflowFromVersion\" has rights \"Execute\" for \"SecuritySpecsUser\"" +
                    " with password \"ASfas123@!fda\" in \"Users\" group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("workflow \"ResumeWorkflowFromVersion\" has \"0\" Versions in explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.When("\"ResumeWorkflowFromVersion\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table598 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table598.AddRow(new string[] {
                        "1",
                        "[[rec(1).a]] = New"});
            table598.AddRow(new string[] {
                        "2",
                        "[[rec(2).a]] = Test"});
#line 17
 testRunner.And("the \"VarsAssign\" in Workflow \"ResumeWorkflowFromVersion\" debug outputs as", ((string)(null)), table598, "And ");
#line hidden
            TechTalk.SpecFlow.Table table599 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table599.AddRow(new string[] {
                        "[[variable]]",
                        "NewlyAddedVariable"});
#line 21
 testRunner.Then("I update \"ResumeWorkflowFromVersion\" by adding \"AnotherVarsAssign\" as", ((string)(null)), table599, "Then ");
#line 24
 testRunner.When("workflow \"ResumeWorkflowFromVersion\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table600 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table600.AddRow(new string[] {
                        "[[ThirdAssignVariable]]",
                        "ThirdAssignVariable"});
#line 25
 testRunner.Then("I update \"ResumeWorkflowFromVersion\" by adding \"ThirVarAssign\" as", ((string)(null)), table600, "Then ");
#line 28
 testRunner.When("workflow \"ResumeWorkflowFromVersion\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.And("I reload Server resources", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I resume the workflow \"ResumeWorkflowFromVersion\" at \"VarsAssign\" from version \"2" +
                    "\"  with user \"SecuritySpecsUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table601 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table601.AddRow(new string[] {
                        "1",
                        "[[rec(1).a]] = New"});
            table601.AddRow(new string[] {
                        "2",
                        "[[rec(2).a]] = Test"});
#line 32
 testRunner.And("the \"VarsAssign\" in Workflow \"ResumeWorkflowFromVersion\" debug outputs as", ((string)(null)), table601, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Resuming a workflow with an Invalid User Returns Authentication Error")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkflowResume")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ResumeWorkflowExecution")]
        public virtual void ResumingAWorkflowWithAnInvalidUserReturnsAuthenticationError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resuming a workflow with an Invalid User Returns Authentication Error", new string[] {
                        "ResumeWorkflowExecution"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given("I have a server at \"localhost\" with workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.And("Resource \"Hello World\" has rights \"Execute\" for \"SecuritySpecsUser\" with password" +
                    " \"ASfas123@!fda\" in \"Users\" group", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("Workflow \"Hello World\" has \"Assign a value to Name if blank (1)\" activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.Then("Resume workflow \"Hello World\" at \"Assign a value to Name if blank (1)\" tool with " +
                    "user \"InvalidUsername\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.Then("Resume has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.Then("Resume message is \"Authentication Error resuming. User InvalidUsername is not aut" +
                    "horized to execute the workflow.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
