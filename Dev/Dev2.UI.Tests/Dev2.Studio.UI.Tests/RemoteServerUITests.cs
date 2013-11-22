﻿using System;
using System.Windows;
using System.Windows.Forms;
using Dev2.CodedUI.Tests.UIMaps.ExplorerUIMapClasses;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Studio.UI.Tests
{
    /// <summary>
    ///     These are UI tests based on using a remote server
    /// </summary>
    [CodedUITest]
    public class RemoteServerUiTests : UIMapBase
    {
        #region Fields

        const string RemoteServerName = "RemoteConnection";
        const string LocalHostServerName = "localhost";
        const string ExplorerTab = "Explorer";

        #endregion

        #region Cleanup

        [ClassInitialize]
        public static void ClassInit(TestContext tctx)
        {
            Playback.Initialize();
            Playback.PlaybackSettings.ContinueOnError = true;
            Playback.PlaybackSettings.ShouldSearchFailFast = true;
            Playback.PlaybackSettings.SmartMatchOptions = SmartMatchOptions.None;
            Playback.PlaybackSettings.MatchExactHierarchy = true;
            Playback.PlaybackSettings.DelayBetweenActions = 1;

            // make the mouse quick ;)
            Mouse.MouseMoveSpeed = 10000;
            Mouse.MouseDragSpeed = 10000;
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            TabManagerUIMap.CloseAllTabs();
            ExplorerUIMap.ClickServerInServerDDL(LocalHostServerName);
        }

        #endregion

        #region Test Methods

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_ConnectToRemoteServerFromExplorer_RemoteServerConnected()
        {
            ExplorerUIMap.ClickServerInServerDDL(RemoteServerName);
            var selectedSeverName = ExplorerUIMap.GetSelectedSeverName();
            Assert.AreEqual(RemoteServerName, selectedSeverName);

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_CreateRemoteWorkFlow_WorkflowIsCreated()
        {
            ExplorerUIMap.ClickServerInServerDDL(RemoteServerName);
            RibbonUIMap.CreateNewWorkflow();
            var activeTabName = TabManagerUIMap.GetActiveTabName();
            Assert.IsTrue(activeTabName.Contains("Unsaved"));
            Assert.IsTrue(activeTabName.Contains("RemoteConnection"));

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_EditRemoteWorkFlow_WorkflowIsEdited()
        {

            const string TextToSearchWith = "Find Records";
            OpenWorkFlow(RemoteServerName, "WORKFLOWS", "TESTS", TextToSearchWith);
            var uiControl = WorkflowDesignerUIMap.FindControlByAutomationId(TabManagerUIMap.GetActiveTab(), "Assign");
            var p = WorkflowDesignerUIMap.GetPointUnderControl(uiControl);
            ToolboxUIMap.DragControlToWorkflowDesigner("Assign", p);
            var activeTabName = TabManagerUIMap.GetActiveTabName();
            Assert.IsTrue(activeTabName.Contains("Find Records - RemoteConnection *"));

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_ViewRemoteWorkFlowInBrowser_WorkflowIsExecuted()
        {

            const string TextToSearchWith = "Find Records";
            OpenWorkFlow(RemoteServerName, "WORKFLOWS", "TESTS", TextToSearchWith);
            OpenMenuItem("View in Browser");
            Playback.Wait(5000);
            //assert error dialog not showing
            var child = DockManagerUIMap.UIBusinessDesignStudioWindow.GetChildren()[0];
            if (child != null)
            {
                Assert.IsNotInstanceOfType(child.GetChildren()[0], typeof (Window));
            }
            else
            {
                Assert.Fail("Cannot get studio window after remote workflow show in browser");
            }

            //Try close browser
            ExternalUIMap.CloseAllInstancesOfIE();

        }

        
        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_DragAndDropWorkflowFromRemoteServerOnALocalHostCreatedWorkflow_WorkFlowIsDroppedAndCanExecute()
        {

            const string TextToSearchWith = "Recursive File Copy";
            //Ensure that we're in localhost
            ExplorerUIMap.ClickServerInServerDDL(LocalHostServerName);
            //Create a workfliow
            RibbonUIMap.CreateNewWorkflow();
            var theTab = TabManagerUIMap.GetActiveTab();
            ExplorerUIMap.ClickServerInServerDDL(RemoteServerName);

            var point = WorkflowDesignerUIMap.GetStartNodeBottomAutoConnectorPoint();

            ExplorerUIMap.EnterExplorerSearchText(TextToSearchWith);
            ExplorerUIMap.DragControlToWorkflowDesigner(RemoteServerName, "WORKFLOWS", "UTILITY", TextToSearchWith, point);

            OpenMenuItem("Debug");
            PopupDialogUIMap.WaitForDialog();
            DebugUIMap.ClickExecute();
            OutputUIMap.WaitForExecution();

            Assert.IsFalse(OutputUIMap.IsAnyStepsInError(), "The remote workflow threw errors when executed locally");
            Assert.IsTrue(WorkflowDesignerUIMap.DoesControlExistOnWorkflowDesigner(theTab, TextToSearchWith));
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_OpenWorkflowOnRemoteServerAndOpenWorkflowWithSameNameOnLocalHost_WorkflowIsOpened()
        {

            const string TextToSearchWith = "Find Records";

            OpenWorkFlow(RemoteServerName, "WORKFLOWS", "TESTS", TextToSearchWith);
            var remoteTab = TabManagerUIMap.FindTabByName(TextToSearchWith + " - " + RemoteServerName);
            Assert.IsNotNull(remoteTab);

            OpenWorkFlow(LocalHostServerName, "WORKFLOWS", "TESTS", TextToSearchWith);
            var localHostTab = TabManagerUIMap.FindTabByName(TextToSearchWith);
            Assert.IsNotNull(localHostTab);

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_DebugARemoteWorkflowWhenLocalWorkflowWithSameNameIsOpen_WorkflowIsExecuted()
        {

            const string TextToSearchWith = "Find Records";

            OpenWorkFlow(LocalHostServerName, "WORKFLOWS", "TESTS", TextToSearchWith);
            var localHostTab = TabManagerUIMap.FindTabByName(TextToSearchWith);
            Assert.IsNotNull(localHostTab);

            OpenWorkFlow(RemoteServerName, "WORKFLOWS", "TESTS", TextToSearchWith);

            OpenMenuItem("Debug");
            PopupDialogUIMap.WaitForDialog();
            DebugUIMap.ClickExecute();
            OutputUIMap.WaitForExecution();

            var remoteTab = TabManagerUIMap.FindTabByName(TextToSearchWith + " - " + RemoteServerName);
            var canidateTab = TabManagerUIMap.GetActiveTab();
            Assert.IsNotNull(remoteTab);
            // verify the active tab is the remote tab
            Assert.AreEqual(remoteTab, canidateTab);
            Assert.IsTrue(OutputUIMap.IsExecutionRemote());

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_EditRemoteDbSource_DbSourceIsEdited()
        {

            const string TextToSearchWith = "DBSource";
            OpenWorkFlow(RemoteServerName, "SOURCES", "REMOTETESTS", TextToSearchWith);
            Playback.Wait(3500);
            SendKeys.SendWait("{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{ENTER}");
            Playback.Wait(1000);
            SaveDialogUIMap.ClickSave();

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_EditRemoteWebSource_WebSourceIsEdited()
        {
            const string TextToSearchWith = "WebSource";
            OpenWorkFlow(RemoteServerName, "SOURCES", "REMOTETESTS", TextToSearchWith);
            Playback.Wait(3500);
            SendKeys.SendWait("{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{ENTER}");
            Playback.Wait(1000);
            SaveDialogUIMap.ClickSave();

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_EditRemoteWebService_WebServiceIsEdited()
        {
            Assert.Fail("Bad test! Not indicative that things worked!");

            //const string TextToSearchWith = "WebService";
            //OpenWorkFlow(RemoteServerName, "SERVICES", "REMOTEUITESTS", TextToSearchWith);
            //Playback.Wait(3500);
            //SendKeys.SendWait("{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{ENTER}");
            //Playback.Wait(1000);
            //SaveDialogUIMap.ClickSave();


        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_EditRemoteDbService_DbServiceIsEdited()
        {
            Assert.Fail("Bad test! Not indicative that things worked!");
            //const string TextToSearchWith = "DBService";
            //OpenWorkFlow(RemoteServerName, "SERVICES", "REMOTEUITESTS", TextToSearchWith);
            //Playback.Wait(3500);
            //Keyboard.SendKeys("{TAB}{TAB}{TAB}{TAB}{TAB}{ENTER}");
 
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_EditRemoteEmailSource_EmailSourceIsEdited()
        {

            Assert.Fail("External mail server issues!");

            //const string TextToSearchWith = "EmailSource";
            //OpenWorkFlow(RemoteServerName, "SOURCES", "REMOTETESTS", TextToSearchWith);
            //Playback.Wait(3500);

            ////Playback.Wait(1000);
            ////SaveDialogUIMap.ClickSave();

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_EditRemotePluginSource_PluginSourceIsEdited()
        {
            const string TextToSearchWith = "PluginSource";
            OpenWorkFlow(RemoteServerName, "SOURCES", "REMOTETESTS", TextToSearchWith);
            Playback.Wait(3500);
            Keyboard.SendKeys("{TAB}{TAB}{TAB}{ENTER}");
            Playback.Wait(1000);
            SaveDialogUIMap.ClickSave();

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_EditRemotePluginService_PluginServiceIsEdited()
        {

            const string TextToSearchWith = "PluginService";
            OpenWorkFlow(RemoteServerName, "SERVICES", "REMOTEUITESTS", TextToSearchWith);
            Playback.Wait(3500);
            PluginServiceWizardUIMap.ClickTest();
            Playback.Wait(1000);
            PluginServiceWizardUIMap.ClickOK();

        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("RemoteServerUITests")]
        public void RemoteServerUITests_AddRenameAndDeleteARemoteWorkFlow_CompletesSuccessfully()
        {

            var serviceType = "WORKFLOWS";
            var folderName = "Unassigned";

            ExplorerUIMap.ClickServerInServerDDL(RemoteServerName);

            //CREATE A WORKFLOW
            RibbonUIMap.CreateNewWorkflow();

            var point = WorkflowDesignerUIMap.GetStartNodeBottomAutoConnectorPoint();
            ToolboxUIMap.DragControlToWorkflowDesigner("Assign", point);

            //SAVE A WORKFLOW
            OpenMenuItem("Save");
            Playback.Wait(2000);
            string InitialName = Guid.NewGuid().ToString();
            EnternameAndSave(InitialName);

            //RENAME A WORKFLOW
            ExplorerUIMap.EnterExplorerSearchText(InitialName);
            Playback.Wait(2000);
            ExplorerUIMap.RightClickRenameProject(RemoteServerName, serviceType, folderName, InitialName);
            string RenameTo = Guid.NewGuid().ToString();
            SendKeys.SendWait(RenameTo + "{ENTER}");

            //DELETE A WORKFLOW
            ExplorerUIMap.EnterExplorerSearchText(RenameTo);
            ExplorerUIMap.RightClickDeleteProject(RemoteServerName, serviceType, folderName, RenameTo);
            Assert.IsFalse(ExplorerUIMap.ServiceExists(RemoteServerName, serviceType, folderName, RenameTo));

        }

        #endregion

        #region Utils

        void EnternameAndSave(string tempName)
        {
            SaveDialogUIMap.ClickAndTypeInNameTextbox(tempName);
            Keyboard.SendKeys("{TAB}{TAB}{ENTER}");
            Playback.Wait(3000);
        }

        void OpenMenuItem(string itemType)
        {
            RibbonUIMap.ClickRibbonMenuItem(itemType);
        }

        void OpenWorkFlow(string serverName, string serviceType, string foldername, string textToSearchWith)
        {
            ExplorerUIMap.ClickServerInServerDDL(serverName);
            ExplorerUIMap.EnterExplorerSearchText(textToSearchWith);
            ExplorerUIMap.DoubleClickOpenProject(serverName, serviceType, foldername, textToSearchWith);
            Playback.Wait(1500);
        }

        #endregion
    }
}