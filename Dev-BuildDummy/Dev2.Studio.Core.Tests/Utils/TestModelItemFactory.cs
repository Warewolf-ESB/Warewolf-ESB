﻿using System.Activities.Presentation;
using System.Activities.Presentation.Model;

namespace Dev2.Core.Tests.Utils
{
    public static class TestModelItemFactory
    {
        public static ModelItem CreateModelItem(object objectToMakeModelItem)
        {
            EditingContext ec = new EditingContext();
            ModelTreeManager mtm = new ModelTreeManager(ec);

            mtm.Load(objectToMakeModelItem);

            return mtm.Root;
        }
    }
}
