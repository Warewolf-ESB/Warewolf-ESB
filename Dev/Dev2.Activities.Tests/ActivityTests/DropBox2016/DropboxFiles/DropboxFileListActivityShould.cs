﻿using Dev2.Activities.DropBox2016;
using Dev2.Activities.DropBox2016.DropboxFileActivity;
using Dev2.Activities.DropBox2016.Result;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Data.ServiceModel;
using Dev2.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Dev2.Common.Interfaces.Wrappers;
using Dev2.Interfaces;
using Warewolf.Storage;
using Warewolf.Storage.Interfaces;
using Dev2.Common.Interfaces.Dropbox;

namespace Dev2.Tests.Activities.ActivityTests.DropBox2016.DropboxFiles
{
    [TestClass]

    public class DropboxFileListActivityShould
    {
        static DsfDropboxFileListActivity CreateDropboxActivity()
        {
            return new DsfDropboxFileListActivity();
        }

        static IExecutionEnvironment CreateExecutionEnvironment()
        {
            return new ExecutionEnvironment();
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void DsfDropboxFileList_GivenNewInstance_ShouldNotBeNull()
        {
            //---------------Set up test pack-------------------
            var dropboxFileListActivity = CreateDropboxActivity();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.IsNotNull(dropboxFileListActivity);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void CreateNewActivity_GivenIsNew_ShouldHaveDisplayName()
        {
            //---------------Set up test pack-------------------
            var dropboxFileListActivity = CreateDropboxActivity();
            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.AreEqual("List Dropbox Contents", dropboxFileListActivity.DisplayName);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void GetFindMissingType_GivenIsNew_ShouldSetStaticActivity()
        {
            //---------------Set up test pack-------------------
            var dropboxFileListActivity = CreateDropboxActivity();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var enFindMissingType = dropboxFileListActivity.GetFindMissingType();
            //---------------Test Result -----------------------
            Assert.AreEqual(enFindMissingType.StaticActivity, enFindMissingType);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void GetDebugInputs_GivenEnvironmentIsNull_ShouldHaveNoDebugOutputs()
        {
            //---------------Set up test pack-------------------
            var dropboxFileListActivity = CreateDropboxActivity();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var debugInputs = dropboxFileListActivity.GetDebugInputs(null, 0);
            //---------------Test Result -----------------------
            Assert.AreEqual(0, debugInputs.Count());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void GetDebugInputs_GivenEnvironmentMockEnvironmentAndFromPath_ShouldHaveOneDebugOutputs()
        {
            //---------------Set up test pack-------------------
            var dropboxFileListActivity = CreateDropboxActivity();
            dropboxFileListActivity.ToPath = "Random.txt";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var debugInputs = dropboxFileListActivity.GetDebugInputs(CreateExecutionEnvironment(), 0);
            //---------------Test Result -----------------------
            Assert.AreEqual(4, debugInputs.Count());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void GetDebugOutputs_GivenWebRequestSuccess_ShouldCorrectDebugValue()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            mockExecutor.Setup(executor => executor.ExecuteTask(TestConstant.DropboxClientInstance.Value))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropBoxDownloadActivityMock = new DsfDropboxFileListActivity();
            dropBoxDownloadActivityMock.GetDropboxSingleExecutor(mockExecutor.Object);
            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropBoxDownloadActivityMock);
            //---------------Execute Test ----------------------
            var executionEnvironment = new Mock<IExecutionEnvironment>().Object;
            
            var debugOutputs = dropBoxDownloadActivityMock.GetDebugOutputs(executionEnvironment, 0);
            //---------------Test Result -----------------------
            Assert.AreEqual(0, debugOutputs.Count);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void GetDebugOutputs_GivenFileMetadataIsNotNull_ShouldHaveOneDebugOutPuts()
        {
            //---------------Set up test pack-------------------
            var dropBoxDownloadActivity = new Mock<DsfDropboxFileListActivity>();
            dropBoxDownloadActivity.SetupAllProperties();
            dropBoxDownloadActivity.Setup(
                acivtity => acivtity.GetDebugOutputs(It.IsAny<IExecutionEnvironment>(), It.IsAny<int>()))
                .Returns(new List<DebugItem>
                {
                    new DebugItem()
                });
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var debugOutputs = dropBoxDownloadActivity.Object.GetDebugOutputs(CreateExecutionEnvironment(), 0);
            //---------------Test Result -----------------------
            Assert.AreEqual(1, debugOutputs.Count());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void ExecuteTool_GivenPaths_ShouldExecuteTool()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            mockExecutor.Setup(executor => executor.ExecuteTask(TestConstant.DropboxClientInstance.Value))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new DsfDropboxFileListActivity { ToPath = "Test.a" };
            dropboxFileListActivity.GetDropboxSingleExecutor(mockExecutor.Object);
            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            var datObj = new Mock<IDSFDataObject>();
            var executionEnvironment = new Mock<IExecutionEnvironment>();
            datObj.Setup(o => o.Environment).Returns(executionEnvironment.Object);
            
            //---------------Test Result -----------------------
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void PerformExecution_GivenNoPaths_ShouldReturnSuccess()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            var clientFactoryMock = new Mock<IDropboxFactory>();
            mockExecutor.Setup(executor => executor.ExecuteTask(It.IsAny<IDropboxClientWrapper>()))
            .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object)
            {
                SelectedSource = new DropBoxSource
                {
                    AccessToken = "Test"
                },
                IsFoldersSelected = true,
            };

            dropboxFileListActivity.DropboxResult = new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value);

            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            var execution = dropboxFileListActivity.PerformBaseExecution(new Dictionary<string, string>
            {
                {"ToPath", ""},
                {"IsRecursive", "false"},
                {"IncludeMediaInfo", "false"},
                {"IncludeDeleted", "false"},
                {"IncludeFolders", "false"}
            });
            //---------------Test Result -----------------------
            Assert.AreEqual(execution, GlobalConstants.DropBoxSuccess);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void PerformExecution_GivenPath_ShouldReturnSuccess()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            var clientFactoryMock = new Mock<IDropboxFactory>();
            mockExecutor.Setup(executor => executor.ExecuteTask(clientFactoryMock.Object.CreateWithSecret("TEST")))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object)
            {
                SelectedSource = new DropBoxSource
                {
                    AccessToken = "Test"
                },
                IsFoldersSelected = true,
            };

            dropboxFileListActivity.DropboxResult = new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value);

            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            var execution = dropboxFileListActivity.PerformBaseExecution(new Dictionary<string, string>
            {
                {"ToPath", "a.txt"},
                {"IsRecursive", "false"},
                {"IncludeMediaInfo", "false"},
                {"IncludeDeleted", "false"},
                {"IncludeFolders", "false"}
            });
            //---------------Test Result -----------------------
            Assert.AreEqual(execution, GlobalConstants.DropBoxSuccess);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void PerformExecution_GivenPathAndIncludeFolders_ShouldLoadFolders()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            var clientFactoryMock = new Mock<IDropboxFactory>();
            mockExecutor.Setup(executor => executor.ExecuteTask(clientFactoryMock.Object.CreateWithSecret("TEST")))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object)
            {
                SelectedSource = new DropBoxSource
                {
                    AccessToken = "Test"
                },
                IsFoldersSelected = true,
            };

            dropboxFileListActivity.DropboxResult = new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value);

            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            dropboxFileListActivity.PerformBaseExecution(new Dictionary<string, string>
            {
                {"ToPath", "a.txt"},
                {"IsRecursive", "false"},
                {"IncludeMediaInfo", "false"},
                {"IncludeDeleted", "false"},
                {"IncludeFolders", "true"}
            });
            //---------------Test Result -----------------------
            Assert.AreEqual(3, dropboxFileListActivity.Files.Count());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void PerformExecution_GivenPathAndIsFilesAndFoldersSelected_ShouldLoadFoldersAndFiles()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            var clientFactoryMock = new Mock<IDropboxFactory>();
            mockExecutor.Setup(executor => executor.ExecuteTask(clientFactoryMock.Object.CreateWithSecret("TEST")))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object)
            {
                SelectedSource = new DropBoxSource
                {
                    AccessToken = "Test"
                },
                IsFilesAndFoldersSelected = true
            };

            dropboxFileListActivity.DropboxResult = new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value);

            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            dropboxFileListActivity.PerformBaseExecution(new Dictionary<string, string>
            {
                {"ToPath", "a.txt"},
                {"IsRecursive", "false"},
                {"IncludeMediaInfo", "false"},
                {"IncludeDeleted", "false"},
                {"IncludeFolders", "true"}
            });
            //---------------Test Result -----------------------
            Assert.AreEqual(3, dropboxFileListActivity.Files.Count());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void
            PerformExecution_GivenPathAndIsFilesAndFoldersSelectedAndIncludeDeleted_ShouldLoadFoldersAndFilesAndDeleted()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            var clientFactoryMock = new Mock<IDropboxFactory>();
            mockExecutor.Setup(executor => executor.ExecuteTask(clientFactoryMock.Object.CreateWithSecret("TEST")))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object)
            {
                SelectedSource = new DropBoxSource
                {
                    AccessToken = "Test"
                },
                IsFilesAndFoldersSelected = true,
                IncludeDeleted = true
            };

            dropboxFileListActivity.DropboxResult = new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value);

            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            dropboxFileListActivity.PerformBaseExecution(new Dictionary<string, string>
            {
                {"ToPath", "a.txt"},
                {"IsRecursive", "false"},
                {"IncludeMediaInfo", "false"},
                {"IncludeDeleted", "false"},
                {"IncludeFolders", "true"}
            });
            //---------------Test Result -----------------------
            Assert.AreEqual(4, dropboxFileListActivity.Files.Count());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void PerformExecution_GivenPathAndIncludeDeleted_ShouldLoadDeletedFiles()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            var clientFactoryMock = new Mock<IDropboxFactory>();
            mockExecutor.Setup(executor => executor.ExecuteTask(clientFactoryMock.Object.CreateWithSecret("TEST")))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object)
            {
                SelectedSource = new DropBoxSource
                {
                    AccessToken = "Test"
                },
                IncludeDeleted = true
            };

            dropboxFileListActivity.DropboxResult = new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value);

            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            dropboxFileListActivity.PerformBaseExecution(new Dictionary<string, string>
            {
                {"ToPath", "a.txt"},
                {"IsRecursive", "false"},
                {"IncludeMediaInfo", "false"},
                {"IncludeDeleted", "true"},
                {"IncludeFolders", "false"}
            });
            //---------------Test Result -----------------------
            Assert.AreEqual(1, dropboxFileListActivity.Files.Count());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void PerformExecution_GivenPathNotIncludeFolders_ShouldLoadNotLoadFolders()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            var clientFactoryMock = new Mock<IDropboxFactory>();
            mockExecutor.Setup(executor => executor.ExecuteTask(clientFactoryMock.Object.CreateWithSecret("TEST")))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object)
            {
                SelectedSource = new DropBoxSource
                {
                    AccessToken = "Test"
                }
            };

            dropboxFileListActivity.DropboxResult = new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value);

            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            dropboxFileListActivity.PerformBaseExecution(new Dictionary<string, string>
            {
                {"ToPath", "a.txt"},
                {"IsRecursive", "false"},
                {"IncludeMediaInfo", "false"},
                {"IncludeDeleted", "false"},
                {"IncludeFolders", "false"}
            });
            //---------------Test Result -----------------------
            Assert.AreEqual(0, dropboxFileListActivity.Files.Count());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void PerformExecution_GivenHasError_ShouldReturnExceptionMessage()
        {
            try
            {
                //---------------Set up test pack-------------------
                var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
                var clientFactoryMock = new Mock<IDropboxFactory>();
                mockExecutor.Setup(executor => executor.ExecuteTask(clientFactoryMock.Object.CreateWithSecret("TEST")))
                    .Returns(new DropboxFailureResult(TestConstant.ExceptionInstance.Value));
                var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object);
                dropboxFileListActivity.SelectedSource =
                    new DropBoxSource
                    {
                        AccessToken = "Test"
                    };

                dropboxFileListActivity.DropboxResult = new DropboxFailureResult(TestConstant.ExceptionInstance.Value);

                dropboxFileListActivity.GetDropboxSingleExecutor(mockExecutor.Object);
                //---------------Assert Precondition----------------
                Assert.IsNotNull(dropboxFileListActivity);
                //---------------Execute Test ----------------------
            }
            catch (Exception e)
            {
                Assert.AreEqual(TestConstant.ExceptionInstance.Value.Message, e.Message);
            }
            //---------------Test Result -----------------------
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void ExecuteTool_GivenNoToPath_ShouldExecuteTool()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            mockExecutor.Setup(executor => executor.ExecuteTask(TestConstant.DropboxClientInstance.Value))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new DsfDropboxFileListActivity { ToPath = "" };
            dropboxFileListActivity.GetDropboxSingleExecutor(mockExecutor.Object);
            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            var datObj = new Mock<IDSFDataObject>();
            var executionEnvironment = new Mock<IExecutionEnvironment>();
            datObj.Setup(o => o.Environment).Returns(executionEnvironment.Object);
            
            //---------------Test Result -----------------------
        }

        [TestMethod]
        public void GetDropboxClient_GivenActivityIsNewAndSourceIsSelected_ShouldCreateNewClient()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            mockExecutor.Setup(executor => executor.ExecuteTask(TestConstant.DropboxClientInstance.Value))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new DsfDropboxFileListActivity();
            dropboxFileListActivity.GetDropboxSingleExecutor(mockExecutor.Object);
            dropboxFileListActivity.SelectedSource = new DropBoxSource
            {
                AccessToken = "Test"
            };
            var privateObject = new PrivateObject(dropboxFileListActivity);
            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------

            var dropboxClient = privateObject.Invoke("GetDropboxClient");
            //---------------Test Result -----------------------
            Assert.IsNotNull(dropboxClient);
        }

        [TestMethod]
        public void GetDropboxClient_GivenClientExists_ShouldReturnExistingClient()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            mockExecutor.Setup(executor => executor.ExecuteTask(TestConstant.DropboxClientInstance.Value))
                .Returns(new DropboxListFolderSuccesResult(TestConstant.ListFolderResultInstance.Value));
            var dropboxFileListActivity = new DsfDropboxFileListActivity();
            dropboxFileListActivity.GetDropboxSingleExecutor(mockExecutor.Object);
            dropboxFileListActivity.SelectedSource = new DropBoxSource
            {
                AccessToken = "Test"
            };

            var privateObject = new PrivateObject(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            var dropboxClient = privateObject.Invoke("GetDropboxClient");
            var dropboxClient1 = privateObject.Invoke("GetDropboxClient");

            //---------------Test Result -----------------------
            Assert.IsNotNull(dropboxClient);
            Assert.IsNotNull(dropboxClient1);
            Assert.AreEqual(dropboxClient, dropboxClient1);
        }

        [TestMethod]
        [Owner("Clint Stedman")]
        [ExpectedException(typeof(Exception))]
        public void PerformExecution_GivenHasError_ShouldReturnDropboxFailureResult()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            var clientFactoryMock = new Mock<IDropboxFactory>();
            mockExecutor.Setup(executor => executor.ExecuteTask(clientFactoryMock.Object.CreateWithSecret("TEST")))
                .Returns(new DropboxFailureResult(new Exception("Test Exception")));
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object);
            dropboxFileListActivity.DropboxResult = new DropboxFailureResult(TestConstant.ExceptionInstance.Value);
            dropboxFileListActivity.SelectedSource =
                new DropBoxSource
                {
                    AccessToken = "Test"
                };
            dropboxFileListActivity.GetDropboxSingleExecutor(mockExecutor.Object);
            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            dropboxFileListActivity.PerformBaseExecution(new Dictionary<string, string>
            {
                {"ToPath", "@()*&$%"},
                {"IsRecursive", "false"},
                {"IncludeMediaInfo", "false"},
                {"IncludeDeleted", "false"},
                {"IncludeFolders", "false"}
            });
            //---------------Test Result -----------------------
            Assert.Fail("Exception Not Throw");
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        [ExpectedException(typeof(Exception))]
        public void PerformExecution_GivenNoToPath_ShouldPassesThrough()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            mockExecutor.Setup(executor => executor.ExecuteTask(It.IsAny<IDropboxClientWrapper>()))
                .Returns(new DropboxFailureResult(new Exception("Test Exception")));
            var mock = new Mock<IDropboxFactory>();
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(mock.Object);
            dropboxFileListActivity.DropboxResult = new DropboxFailureResult(TestConstant.ExceptionInstance.Value);
            dropboxFileListActivity.SelectedSource =
                new DropBoxSource
                {
                    AccessToken = "Test"
                };
            dropboxFileListActivity.GetDropboxSingleExecutor(mockExecutor.Object);
            //---------------Assert Precondition----------------
            Assert.IsNotNull(dropboxFileListActivity);
            //---------------Execute Test ----------------------
            dropboxFileListActivity.PerformBaseExecution(new Dictionary<string, string>
            {
              
            });
            //---------------Test Result -----------------------
            mockExecutor.Verify(executor => executor.ExecuteTask(It.IsAny<IDropboxClientWrapper>()));
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void GetDebugInputs_GivenValues_ShouldAddDebugInputs()
        {
            //---------------Set up test pack-------------------
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            var clientFactoryMock = new Mock<IDropboxFactory>();
            mockExecutor.Setup(executor => executor.ExecuteTask(clientFactoryMock.Object.CreateWithSecret("TEST")))
                .Returns(new DropboxFailureResult(new Exception("Test Exception")));
            var dropboxFileListActivity = new TestDsfDropboxFileListActivity(clientFactoryMock.Object);
            dropboxFileListActivity.DropboxResult = new DropboxFailureResult(TestConstant.ExceptionInstance.Value);
            dropboxFileListActivity.SelectedSource =
                new DropBoxSource
                {
                    AccessToken = "Test"
                };
            dropboxFileListActivity.GetDropboxSingleExecutor(mockExecutor.Object);
            dropboxFileListActivity.IsFilesSelected = true;
            dropboxFileListActivity.IsRecursive = true;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var mockExecutionEnv = new Mock<IExecutionEnvironment>();
            var debugInputs = dropboxFileListActivity.GetDebugInputs(mockExecutionEnv.Object, 0);
            //---------------Test Result -----------------------
            Assert.AreEqual(4,debugInputs.Count());
        }
    }

    public class TestDsfDropboxFileListActivity : DsfDropboxFileListActivity
    {
        readonly IDropboxFactory _clientFactory;

        public TestDsfDropboxFileListActivity(IDropboxFactory clientFactory)
            :base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public string PerformBaseExecution(Dictionary<string, string> evaluatedValues)
        {
            
            return base.PerformExecution(evaluatedValues)[0];
        }

        public IDropboxResult DropboxResult { get; set; }

        public override IDropboxSingleExecutor<IDropboxResult> GetDropboxSingleExecutor(
                IDropboxSingleExecutor<IDropboxResult> singleExecutor)
        {
            var mockExecutor = new Mock<IDropboxSingleExecutor<IDropboxResult>>();
            mockExecutor.Setup(executor => executor.ExecuteTask(_clientFactory.CreateWithSecret("TEST")))
                .Returns(DropboxResult);
            var dropboxFileListActivity = new Mock<TestDsfDropboxFileListActivity>();
            dropboxFileListActivity.Setup(
                mock => mock.GetDropboxSingleExecutor(It.IsAny<IDropboxSingleExecutor<IDropboxResult>>()))
                .Returns(mockExecutor.Object);
            return mockExecutor.Object;
        }
    }
}