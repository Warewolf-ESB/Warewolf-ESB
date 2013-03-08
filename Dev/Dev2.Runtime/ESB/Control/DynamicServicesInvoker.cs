﻿#region Change Log

//  Author:         Sameer Chunilall
//  Date:           2010-01-24
//  Log No:         9299
//  Description:    The data layer of the Dynamic Service Engine
//                  This is where all actions get executed.

#endregion

using Dev2.Common;
using Dev2.DataList.Contract;
using Dev2.DynamicServices;
using Dev2.Runtime.ESB.Control;
using Dev2.Runtime.ESB.Execution;
using Dev2.Workspaces;
using System;
using System.Linq;
using System.Transactions;
using enActionType = Dev2.DynamicServices.enActionType;

namespace Dev2.Runtime.ESB
{

    #region Dynamic Invocation Class - Invokes Dynamic Endpoint and returns responses to the Caller

    
    public class DynamicServicesInvoker : IDynamicServicesInvoker, IDisposable
    {
        #region Fields
        private readonly IEsbChannel _esbChannel;

        private readonly IFrameworkDuplexDataChannel _managementChannel;
        private readonly IWorkspace _workspace;

        #endregion

        // 2012.10.17 - 5782: TWR - Changed to work off the workspace host and made read only

        public bool IsLoggingEnabled
        {
            get { return true; }
        }

        #region Constructors

        public DynamicServicesInvoker()
        {
        }

        public DynamicServicesInvoker(IEsbChannel esbChannel,
                                      IFrameworkDuplexDataChannel managementChannel,
                                      IWorkspace workspace)
        {
            _esbChannel = esbChannel;
            if(managementChannel != null)
            {
                _managementChannel = managementChannel;
            }

            // 2012.10.17 - 5782: TWR - Added workspace parameter
            _workspace = workspace;
        }

        #endregion

        #region Travis New Methods

        /// <summary>
        /// Invokes the specified service as per the dataObject against theHost
        /// </summary>
        /// <param name="theHost">The host.</param>
        /// <param name="dataObject">The data object.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        public Guid Invoke(IDSFDataObject dataObject, out ErrorResultTO errors)
        {
            errors = new ErrorResultTO();
            string serviceName = dataObject.ServiceName;
            Guid result = GlobalConstants.NullDataListID;
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();

            if (string.IsNullOrEmpty(serviceName))
            {
                errors.AddError(Resources.DynamicServiceError_ServiceNotSpecified);
            }
            else
            {
                // Place into a transactional scope
                using(var transactionScope = new TransactionScope())
                {
                    try
                    {
                        ServiceLocator sl = new ServiceLocator();
                        DynamicService theService = sl.FindServiceByName(serviceName, _workspace.Host);

                        if (theService == null)
                        {
                            errors.AddError("Service [ " + serviceName + " ] not found.");   
                        }
                        else if(theService.Actions.Count <= 1)
                        {
                            ServiceAction theStart = theService.Actions.FirstOrDefault();
                            ErrorResultTO invokeErrors = new ErrorResultTO();
                            // Invoke based upon type ;)
                            EsbExecutionContainer container = GenerateContainer(theStart, dataObject, _workspace);
                            result = container.Execute(out invokeErrors);
                            errors.MergeErrors(invokeErrors);

                            // Ensure there are no errors so we can complete transaction
                            if(!compiler.HasErrors(dataObject.DataListID) && result != GlobalConstants.NullDataListID && !invokeErrors.HasErrors())
                            {
                                transactionScope.Complete();
                            }
                        }
                        else
                        {
                            errors.AddError("Malformed Service [ " + serviceName + " ] it contains multiple actions");   
                        }
                    }
                    catch(Exception e)
                    {
                        errors.AddError(e.Message);
                    }
                    finally
                    {
                        ErrorResultTO tmpErrors;
                        compiler.UpsertSystemTag(dataObject.DataListID, enSystemTag.Error, errors.MakeDataListReady(), out tmpErrors);
                        transactionScope.Dispose(); 
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Generates the invoke container.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns></returns>
        public EsbExecutionContainer GenerateInvokeContainer(IDSFDataObject dataObject,string serviceName)
        {
            ServiceLocator sl = new ServiceLocator();
            DynamicService theService = sl.FindServiceByName(serviceName, _workspace.Host);
            EsbExecutionContainer executionContainer = null;


            if(theService != null && theService.Actions.Any())
            {
                ServiceAction sa= theService.Actions.FirstOrDefault();
                executionContainer = GenerateContainer(sa, dataObject, _workspace);

            }

            return executionContainer;
        }

        private EsbExecutionContainer GenerateContainer(ServiceAction serviceAction, IDSFDataObject dataObj, IWorkspace theWorkspace)
        {
            // set the ID for later use ;)
            dataObj.WorkspaceID = _workspace.ID;

            EsbExecutionContainer result = null;

            switch (serviceAction.ActionType)
            {

                //case enActionType.InvokeDynamicService:
                //    //return new InternalServiceContainer(serviceAction, dataObj, theWorkspace);
                    
                //    //result = DynamicService(serviceAction, dataObj.DataListID);

                //    throw new Exception("Please adjust type to that of internal action!!!");
                //break;

                case enActionType.InvokeManagementDynamicService:
                    result = new InternalServiceContainer(serviceAction, dataObj, theWorkspace, _esbChannel);
                break;

                case enActionType.InvokeStoredProc:
                    result = new DatabaseServiceContainer(serviceAction, dataObj, theWorkspace, _esbChannel);
                break;
                case enActionType.InvokeWebService:
                    result = new WebServiceContainer(serviceAction, dataObj, theWorkspace, _esbChannel);
                break;

                case enActionType.Plugin:
                    result = new PluginServiceContainer(serviceAction, dataObj, theWorkspace, _esbChannel);
                break;

                case enActionType.Workflow:
                    result = new WfExecutionContainer(serviceAction, dataObj, theWorkspace, _esbChannel);
                break;
            }

            return result;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        #endregion

    }

    #endregion
}
