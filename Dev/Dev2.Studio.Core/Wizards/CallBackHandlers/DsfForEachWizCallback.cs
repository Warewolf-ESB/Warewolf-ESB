﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Dev2.Studio.Core.Wizards.Interfaces;
using Unlimited.Applications.BusinessDesignStudio.Activities;

namespace Dev2.Studio.Core.Wizards.CallBackHandlers
{
    // Old Wizard Functionlity
    //[Export(typeof(IActivitySpecificSettingsWizardCallbackHandler<DsfForEachActivity>))]
    //[PartCreationPolicy(CreationPolicy.NonShared)]
    public class DsfForEachWizCallback : DsfBaseWizCallback<DsfForEachActivity>
    {
    }
}
