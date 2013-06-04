﻿using Dev2;
using Dev2.Activities;
using Dev2.DataList.Contract;
using Dev2.DataList.Contract.Binary_Objects;
using Dev2.DataList.Contract.Value_Objects;
using Dev2.Diagnostics;
using Dev2.Enums;
using Dev2.PathOperations;
using System;
using System.Activities;
using System.Collections;
using System.Collections.Generic;
using Dev2.Util;
using Dev2.Utilities;
using Unlimited.Applications.BusinessDesignStudio.Activities.Utilities;

namespace Unlimited.Applications.BusinessDesignStudio.Activities
{
    /// <summary>
    /// PBI : 1172
    /// Status : New
    /// Purpose : To provide an activity that can read the contents of a file from FTP, FTPS and file system
    /// </summary>
    public class DsfFileRead : DsfAbstractFileActivity, IPathInput
    {

        public DsfFileRead()
            : base("Read File")
        {
            InputPath = string.Empty;
        }

        protected override IList<OutputTO> ExecuteConcreteAction(NativeActivityContext context, out ErrorResultTO allErrors)
        {

            IList<OutputTO> outputs = new List<OutputTO>();
            IDSFDataObject dataObject = context.GetExtension<IDSFDataObject>();
            //IDataListCompiler compiler = context.GetExtension<IDataListCompiler>();
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();

            allErrors = new ErrorResultTO();
            ErrorResultTO errors = new ErrorResultTO();
            Guid executionId = dataObject.DataListID;
            IDev2IteratorCollection colItr = Dev2ValueObjectFactory.CreateIteratorCollection();

            //get all the possible paths for all the string variables
            IBinaryDataListEntry inputPathEntry = compiler.Evaluate(executionId, enActionType.User, InputPath, false, out errors);
            allErrors.MergeErrors(errors);
            IDev2DataListEvaluateIterator inputItr = Dev2ValueObjectFactory.CreateEvaluateIterator(inputPathEntry);
            colItr.AddIterator(inputItr);

            IBinaryDataListEntry usernameEntry = compiler.Evaluate(executionId, enActionType.User, Username, false, out errors);
            allErrors.MergeErrors(errors);
            IDev2DataListEvaluateIterator unameItr = Dev2ValueObjectFactory.CreateEvaluateIterator(usernameEntry);
            colItr.AddIterator(unameItr);

            IBinaryDataListEntry passwordEntry = compiler.Evaluate(executionId, enActionType.User, Password, false, out errors);
            allErrors.MergeErrors(errors);
            IDev2DataListEvaluateIterator passItr = Dev2ValueObjectFactory.CreateEvaluateIterator(passwordEntry);
            colItr.AddIterator(passItr);

            outputs.Add(DataListFactory.CreateOutputTO(Result));

            if (dataObject.IsDebug)
            {
                AddDebugInputItem(InputPath, "Input Path", inputPathEntry, executionId);                
                AddDebugInputItem(Username, "Username", usernameEntry, executionId);
                AddDebugInputItem(Password, "Password", passwordEntry, executionId);
            }

            while (colItr.HasMoreData())
            {
                IActivityOperationsBroker broker = ActivityIOFactory.CreateOperationsBroker();
                IActivityIOPath IOpath = ActivityIOFactory.CreatePathFromString(colItr.FetchNextRow(inputItr).TheValue,
                                                                                colItr.FetchNextRow(unameItr).TheValue,
                                                                                colItr.FetchNextRow(passItr).TheValue,
                                                                                IsNotCertVerifiable);

                IActivityIOOperationsEndPoint endpoint = ActivityIOFactory.CreateOperationEndPointFromIOPath(IOpath);
                try
                {
                    // Travis.Frisinger - 01.02.2013 - Bug 8579
                    // fake it so we have a deferred read ;) -- Slightly silly, but consistent
                    if(dataObject.IsDebug)
                    {
                        DefferedReadFileContents = broker.Get(endpoint, false);
                    }
                    string result = broker.Get(endpoint);
                    //MakeDeferredAction(IOpath.Path);
                    outputs[0].OutputStrings.Add(result);
                }
                catch(Exception e)
                {
                    allErrors.AddError(e.Message);
                }

            }

            return outputs;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the input path.
        /// </summary>
        [Inputs("Input Path")]
        [FindMissing]
        public string InputPath
        {
            get;
            set;
        }

        #endregion Properties

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates, NativeActivityContext context)
        {
            if (updates.Count == 1)
            {
                InputPath = updates[0].Item2;
            }
        }

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates, NativeActivityContext context)
        {
            if (updates.Count == 1)
            {
                Result = updates[0].Item2;
            }
        }


        #region GetForEachInputs/Outputs

        public override IList<DsfForEachItem> GetForEachInputs(NativeActivityContext context)
        {
            return GetForEachItems(context, StateType.Before, InputPath);
        }

        public override IList<DsfForEachItem> GetForEachOutputs(NativeActivityContext context)
        {
            return GetForEachItems(context, StateType.After, Result);
        }

        #endregion
    }
}
