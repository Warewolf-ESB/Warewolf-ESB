﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unlimited.Framework.Converters.Graph.Interfaces
{
    public interface INavigator : IDisposable
    {
        object Data { get; }
        object SelectScalar(IPath path);
        IEnumerable<object> SelectEnumerable(IPath path);
        Dictionary<IPath, IList<object>> SelectEnumerablesAsRelated(IList<IPath> paths);
    }
}
