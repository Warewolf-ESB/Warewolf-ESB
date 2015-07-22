
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2015 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using Dev2.DataList.Contract;
using Dev2.Services.Execution;

namespace Dev2.Activities
{
    public class MockDsfPluginActivity : DsfPluginActivity
    {

        public PluginServiceExecution MockGetNewPluginServiceExecution(IDSFDataObject context)
        {
            return GetNewPluginServiceExecution(context);
        }

        public Guid MockExecutePluginService(PluginServiceExecution container)
        {
            return ExecutePluginService(container, 0);
        }

        public Guid MockExecutionImpl(IEsbChannel esbChannel, IDSFDataObject dataObject, string inputs, string outputs, out ErrorResultTO tmpErrors)
        {
            return base.ExecutionImpl(esbChannel, dataObject, inputs, outputs, out tmpErrors, 0);
        }
    }

    public class FaultyMockDsfPluginActivity : DsfPluginActivity
    {

        public PluginServiceExecution MockGetNewPluginServiceExecution(IDSFDataObject context)
        {
            return GetNewPluginServiceExecution(context);
        }

        public Guid MockExecutePluginService(PluginServiceExecution container)
        {
            return ExecutePluginService(container, 0);
        }

        public Guid MockExecutionImpl(IEsbChannel esbChannel, IDSFDataObject dataObject, string inputs, string outputs, out ErrorResultTO tmpErrors)
        {
            
            tmpErrors = new ErrorResultTO();
            tmpErrors.AddError("Something bad happened");
            return Guid.Empty;
        }
    }
}
