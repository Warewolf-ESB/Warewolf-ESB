﻿using System;
using System.IO;
using Dev2.Common;
using Dev2.Common.Common;
using Dev2.Data.ServiceModel;
using Dev2.DataList.Contract;
using Dev2.DynamicServices.Test.XML;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.ServiceModel.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Tests.Runtime.ServiceModel
{
    [TestClass]
    public class ResourcesTests
    {

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            Directory.SetCurrentDirectory(testContext.TestDir);
        }

        [TestMethod]
        public void Paths_Expected_JSONSources()
        {
            var workspaceID = Guid.NewGuid();
            var workspacePath = EnvironmentVariables.GetWorkspacePath(workspaceID);
            var servicesPath = Path.Combine(workspacePath, "Services");
            var sourcesPath = Path.Combine(workspacePath, "Sources");
            var pluginsPath = Path.Combine(workspacePath, "Plugins");
            try
            {
                Directory.CreateDirectory(servicesPath);
                Directory.CreateDirectory(sourcesPath);
                Directory.CreateDirectory(pluginsPath);

                var xml = XmlResource.Fetch("Calculate_RecordSet_Subtract");
                xml.Save(Path.Combine(servicesPath, "Calculate_RecordSet_Subtract.xml"));

                xml = XmlResource.Fetch("HostSecurityProviderServerSigned");
                xml.Save(Path.Combine(sourcesPath, "HostSecurityProviderServerSigned.xml"));

                var testResources = new Dev2.Runtime.ServiceModel.Resources();
                var actual = testResources.Paths("", workspaceID, Guid.Empty);
                Assert.AreEqual("[\"Integration Test Services\"]", actual);
            }
            finally
            {
                if(Directory.Exists(workspacePath))
                {
                    DirectoryHelper.CleanUp(workspacePath);
                }
            }
        }

        #region private test methods

        private void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach(string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach(string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            DirectoryHelper.CleanUp(target_dir);
        }

        private Guid generateADLGuid()
        {
            var _compiler = DataListFactory.CreateDataListCompiler();
            ErrorResultTO errors = new ErrorResultTO();
            Guid exID = _compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML), GetSimpleADL(), GetSimpleADLShape(), out errors);
            if(errors.HasErrors())
            {
                string errorString = string.Empty;
                foreach(string item in errors.FetchErrors())
                {
                    errorString += item;
                }

                throw new Exception(errorString);
            }
            return exID;
        }

        private string GetSimpleADL()
        {
            return @"<ADL>
  <cRec>
    <opt></opt>
    <display />
  </cRec>
  <gRec>
    <opt>Value1</opt>
    <display>display1</display>
  </gRec>
  <recset></recset>
  <field></field>
</ADL>";
        }

        private string GetSimpleADLShape()
        {
            return @"<ADL>
  <cRec>
    <opt></opt>
    <display />
  </cRec>
  <gRec>
    <opt></opt>
    <display></display>
  </gRec>
  <recset></recset>
  <field></field>
</ADL>";
        }

        #endregion

        #region Sources

        [TestMethod]
        public void SourcesWithNullArgsExpectedReturnsEmptyList()
        {
            var resources = new Dev2.Runtime.ServiceModel.Resources();
            var result = resources.Sources(null, Guid.Empty, Guid.Empty);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SourcesWithInvalidArgsExpectedReturnsEmptyList()
        {
            var resources = new Dev2.Runtime.ServiceModel.Resources();
            var result = resources.Sources("xxxx", Guid.Empty, Guid.Empty);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SourcesWithValidArgsExpectedReturnsList()
        {
            var workspaceID = Guid.NewGuid();
            var workspacePath = EnvironmentVariables.GetWorkspacePath(workspaceID);
            try
            {
                const int Modulo = 2;
                const int ExpectedCount = 6;
                for(var i = 0; i < ExpectedCount; i++)
                {
                    var resource = new Resource
                    {
                        ResourceID = Guid.NewGuid(),
                        ResourceName = string.Format("My Name {0}", i),
                        ResourcePath = string.Format("My Path {0}", i),
                        ResourceType = (i % Modulo == 0) ? ResourceType.DbSource : ResourceType.Unknown
                    };
                    ResourceCatalog.Instance.SaveResource(workspaceID, resource);
                }
                var resources = new Dev2.Runtime.ServiceModel.Resources();
                var result = resources.Sources("{\"resourceType\":\"" + ResourceType.DbSource + "\"}", workspaceID, Guid.Empty);

                Assert.AreEqual(ExpectedCount / Modulo, result.Count);
            }
            finally
            {
                if(Directory.Exists(workspacePath))
                {
                    DirectoryHelper.CleanUp(workspacePath);
                }
            }
        }
        #endregion

        #region Services

        [TestMethod]
        public void ServicesWithValidArgsExpectedReturnsList()
        {
            var workspaceID = Guid.NewGuid();
            var workspacePath = EnvironmentVariables.GetWorkspacePath(workspaceID);
            try
            {
                const int Modulo = 2;
                const int ExpectedCount = 6;
                for(var i = 0; i < ExpectedCount; i++)
                {
                    var resource = new Resource
                    {
                        ResourceID = Guid.NewGuid(),
                        ResourceName = string.Format("My Name {0}", i),
                        ResourcePath = string.Format("My Path {0}", i),
                        ResourceType = (i % Modulo == 0) ? ResourceType.WorkflowService : ResourceType.Unknown
                    };
                    ResourceCatalog.Instance.SaveResource(workspaceID, resource);
                }
                var resources = new Dev2.Runtime.ServiceModel.Resources();
                var result = resources.Services(ResourceType.WorkflowService.ToString(), workspaceID, Guid.Empty);

                Assert.AreEqual(ExpectedCount / Modulo, result.Count);
            }
            finally
            {
                if(Directory.Exists(workspacePath))
                {
                    DirectoryHelper.CleanUp(workspacePath);
                }
            }
        }

        [TestMethod]
        public void ServicesWithNullArgsExpectedReturnsEmptyList()
        {
            var resources = new Dev2.Runtime.ServiceModel.Resources();
            var result = resources.Services(null, Guid.Empty, Guid.Empty);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ServicesWithInvalidArgsExpectedReturnsEmptyList()
        {
            var resources = new Dev2.Runtime.ServiceModel.Resources();
            var result = resources.Services("xxxx", Guid.Empty, Guid.Empty);
            Assert.AreEqual(0, result.Count);
        }
        #endregion

        #region DataListInputVariables

        [TestMethod]
        public void DataListInputVariablesWhereNullArgsExpectEmptyString()
        {
            //------------Setup for test--------------------------
            var resources = new Dev2.Runtime.ServiceModel.Resources();
            //------------Execute Test---------------------------
            var result = resources.DataListInputVariables(null, Guid.Empty, Guid.Empty);
            //------------Assert Results-------------------------
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void DataListInputVariablesWhereInvalidArgsExpectEmptyString()
        {
            //------------Setup for test--------------------------
            var resources = new Dev2.Runtime.ServiceModel.Resources();
            //------------Execute Test---------------------------
            var result = resources.DataListInputVariables("xxxx", Guid.Empty, Guid.Empty);
            //------------Assert Results-------------------------
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void DataListInputWhereValidArgsDataListHasInputsScalarsAndRecSetExpectCorrectString()
        {
            //------------Setup for test--------------------------
            var workspaceID = Guid.NewGuid();
            var workspacePath = EnvironmentVariables.GetWorkspacePath(workspaceID);
            var servicesPath = Path.Combine(workspacePath, "Services");
            var sourcesPath = Path.Combine(workspacePath, "Sources");
            var pluginsPath = Path.Combine(workspacePath, "Plugins");
            try
            {
                Directory.CreateDirectory(servicesPath);
                Directory.CreateDirectory(sourcesPath);
                Directory.CreateDirectory(pluginsPath);

                var xml = XmlResource.Fetch("TestForEachOutput");
                xml.Save(Path.Combine(servicesPath, "TestForEachOutput.xml"));

                var resources = new Dev2.Runtime.ServiceModel.Resources();
                var resource = ResourceCatalog.Instance.GetResource(workspaceID, "TestForEachOutput");
                //------------Execute Test---------------------------
                var dataListInputVariables = resources.DataListInputVariables(resource.ResourceID.ToString(), workspaceID, Guid.Empty);
                //------------Assert Results-------------------------
                StringAssert.Contains(dataListInputVariables, "inputScalar");
                StringAssert.Contains(dataListInputVariables, "bothScalar");
            }
            finally
            {
                if(Directory.Exists(workspacePath))
                {
                    DirectoryHelper.CleanUp(workspacePath);
                }
            }
        }

        [TestMethod]
        public void DataListInputWhereValidArgsDataListHasNoInputsExpectEmptyString()
        {
            //------------Setup for test--------------------------
            var workspaceID = Guid.NewGuid();
            var workspacePath = EnvironmentVariables.GetWorkspacePath(workspaceID);
            var servicesPath = Path.Combine(workspacePath, "Services");
            var sourcesPath = Path.Combine(workspacePath, "Sources");
            var pluginsPath = Path.Combine(workspacePath, "Plugins");
            try
            {
                Directory.CreateDirectory(servicesPath);
                Directory.CreateDirectory(sourcesPath);
                Directory.CreateDirectory(pluginsPath);

                var xml = XmlResource.Fetch("Bug6619");
                xml.Save(Path.Combine(servicesPath, "Bug6619.xml"));

                var resources = new Dev2.Runtime.ServiceModel.Resources();
                var resource = ResourceCatalog.Instance.GetResource(workspaceID, "Bug6619");
                //------------Execute Test---------------------------
                var dataListInputVariables = resources.DataListInputVariables(resource.ResourceID.ToString(), workspaceID, Guid.Empty);
                //------------Assert Results-------------------------
                Assert.IsTrue(string.IsNullOrEmpty(dataListInputVariables));
            }
            finally
            {
                if(Directory.Exists(workspacePath))
                {
                    DirectoryHelper.CleanUp(workspacePath);
                }
            }
        }
        #endregion

        #region Paths And Names

        [TestMethod]
        [TestCategory("Resources_PathsAndNames")]
        [Description("Correct list of folder names returned for workflow type service")]
        [Owner("Ashley Lewis")]
        // ReSharper disable InconsistentNaming
        public void Resources_UnitTest_WorkflowPathsAndNames_CorrectListReturned()
        // ReSharper restore InconsistentNaming
        {
            //Isolate PathsAndNames for workflows as a functional unit
            var workspaceID = Guid.NewGuid();
            var workspacePath = EnvironmentVariables.GetWorkspacePath(workspaceID);
            try
            {
                const int Modulo = 2;
                const int totalResourceCount = 6;
                for (var i = 0; i < totalResourceCount; i++)
                {
                    var resource = new Dev2.Runtime.ServiceModel.Data.Resource
                    {
                        ResourceID = Guid.NewGuid(),
                        ResourceName = string.Format("My Name {0}", i),
                        ResourcePath = string.Format("My Path {0}", i),
                        ResourceType = (i % Modulo == 0) ? ResourceType.WorkflowService : ResourceType.Unknown
                    };
                    ResourceCatalog.Instance.SaveResource(workspaceID, resource);
                }
                var resources = new Dev2.Runtime.ServiceModel.Resources();
                const string expectedJson = "{\"Names\":[\"My Name 0\",\"My Name 1\",\"My Name 2\",\"My Name 3\",\"My Name 4\",\"My Name 5\"],\"Paths\":[\"MY PATH 0\",\"MY PATH 2\",\"MY PATH 4\"]}";

                //Run PathsAndNames
                var actualJson = resources.PathsAndNames("WorkflowService", workspaceID, Guid.Empty);

                //Assert CorrectListReturned
                Assert.AreEqual(expectedJson, actualJson, "Incorrect list of names and paths for workflow services");
            }
            finally
            {
                if (Directory.Exists(workspacePath))
                {
                    DirectoryHelper.CleanUp(workspacePath);
                }
            }
        }

        [TestMethod]
        [TestCategory("Resources_PathsAndNames")]
        [Description("Correct list of folder names returned for workflow type service")]
        [Owner("Ashley Lewis")]
        // ReSharper disable InconsistentNaming
        public void Resources_UnitTest_PluginPathsAndNames_AllServicePathsExeptWorkflows()
        // ReSharper restore InconsistentNaming
        {
            //Isolate PathsAndNames for workflows as a functional unit
            var workspaceID = Guid.NewGuid();
            var workspacePath = EnvironmentVariables.GetWorkspacePath(workspaceID);
            try
            {
                const int Modulo = 3;
                const int totalResourceCount = 9;
                for (var i = 0; i < totalResourceCount; i++)
                {
                    var resource = new Dev2.Runtime.ServiceModel.Data.Resource
                    {
                        ResourceID = Guid.NewGuid(),
                        ResourceName = string.Format("My Name {0}", i),
                        ResourcePath = string.Format("My Path {0}", i)
                    };

                    switch (i % Modulo)
                    {
                        case 0:
                            resource.ResourceType = ResourceType.WorkflowService;
                            break;
                        case 1:
                            resource.ResourceType = ResourceType.DbService;
                            break;
                        case 2:
                            resource.ResourceType = ResourceType.PluginService;
                            break;
                    }
                    ResourceCatalog.Instance.SaveResource(workspaceID, resource);
                }
                var resources = new Dev2.Runtime.ServiceModel.Resources();
                const string expectedJson = "{\"Names\":[\"My Name 0\",\"My Name 1\",\"My Name 2\",\"My Name 3\",\"My Name 4\",\"My Name 5\",\"My Name 6\",\"My Name 7\",\"My Name 8\"],\"Paths\":[\"MY PATH 1\",\"MY PATH 2\",\"MY PATH 4\",\"MY PATH 5\",\"MY PATH 7\",\"MY PATH 8\"]}";

                //Run PathsAndNames
                var actualJson = resources.PathsAndNames("DbService", workspaceID, Guid.Empty);

                //Assert CorrectListReturned
                Assert.AreEqual(expectedJson, actualJson, "Incorrect list of names and paths for workflow services");
            }
            finally
            {
                if (Directory.Exists(workspacePath))
                {
                    DirectoryHelper.CleanUp(workspacePath);
                }
            }
        }

        [TestMethod]
        [TestCategory("Resources_PathsAndNames")]
        [Description("Correct list of folder names returned for workflow type service")]
        [Owner("Ashley Lewis")]
        // ReSharper disable InconsistentNaming
        public void Resources_UnitTest_SourcePathsAndNames_AllSourcePathsReturned()
        // ReSharper restore InconsistentNaming
        {
            //Isolate PathsAndNames for workflows as a functional unit
            var workspaceID = Guid.NewGuid();
            var workspacePath = EnvironmentVariables.GetWorkspacePath(workspaceID);
            try
            {
                const int Modulo = 2;
                const int totalResourceCount = 6;
                for (var i = 0; i < totalResourceCount; i++)
                {
                    var resource = new Dev2.Runtime.ServiceModel.Data.Resource
                    {
                        ResourceID = Guid.NewGuid(),
                        ResourceName = string.Format("My Name {0}", i),
                        ResourcePath = string.Format("My Path {0}", i),
                        ResourceType = (i % Modulo == 0) ? ResourceType.WebSource : ResourceType.Unknown
                    };
                    ResourceCatalog.Instance.SaveResource(workspaceID, resource);
                }
                var resources = new Dev2.Runtime.ServiceModel.Resources();
                const string expectedJson = "{\"Names\":[\"My Name 0\",\"My Name 1\",\"My Name 2\",\"My Name 3\",\"My Name 4\",\"My Name 5\"],\"Paths\":[\"MY PATH 0\",\"MY PATH 2\",\"MY PATH 4\"]}";

                //Run PathsAndNames
                var actualJson = resources.PathsAndNames("EmailSource", workspaceID, Guid.Empty);

                //Assert CorrectListReturned
                Assert.AreEqual(expectedJson, actualJson, "Incorrect list of names and paths for workflow services");
            }
            finally
            {
                if (Directory.Exists(workspacePath))
                {
                    DirectoryHelper.CleanUp(workspacePath);
                }
            }
        }

        #endregion
    }
}
