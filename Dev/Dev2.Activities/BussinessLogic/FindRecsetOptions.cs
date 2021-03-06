#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Dev2.Common;
using Dev2.DataList.Contract;


namespace Dev2.DataList
{
    /// <summary>
    /// Static class for returning the search option that was selected by the user
    /// </summary>
    public static class FindRecsetOptions
    {

        static Dictionary<string, IFindRecsetOptions> _options = new Dictionary<string, IFindRecsetOptions>();

        /// <summary>
        /// A static constructor is used to initialize any static data,
        ///  or to perform a particular action that needs to be performed once only.
        ///  It is called automatically before the first instance is created or any static members are referenced.
        /// </summary>
        static FindRecsetOptions()
        {
            var type = typeof(IFindRecsetOptions);

            var types = typeof(IFindRecsetOptions).Assembly.GetTypes()
                   .Where(t => type.IsAssignableFrom(t)).ToList();

            foreach (Type t in types)
            {
                if (!t.IsAbstract && !t.IsInterface && Activator.CreateInstance(t, true) is IFindRecsetOptions item)
                {
                    _options.Add(item.HandlesType(), item);
                }

            }
            SortRecordsetOptions();
        }

        static void SortRecordsetOptions()
        {
            var tmpDictionary = new Dictionary<string, IFindRecsetOptions>();

            foreach (string findRecordsOperation in GlobalConstants.FindRecordsOperations)

            {
                var firstOrDefault = _options.FirstOrDefault(c => c.Value.HandlesType().Equals(findRecordsOperation, StringComparison.InvariantCultureIgnoreCase));
                if (!string.IsNullOrEmpty(firstOrDefault.Key))
                {
                    tmpDictionary.Add(firstOrDefault.Key, firstOrDefault.Value);
                }
            }

            _options = tmpDictionary;
        }
        /// <summary>
        /// Find the matching search object
        /// </summary>
        /// <param name="expressionType"></param>
        /// <returns></returns>
        public static IFindRecsetOptions FindMatch(string expressionType)
        {
            if (!_options.TryGetValue(expressionType, out IFindRecsetOptions result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Find all AbstractRecsetSearchValidation objects
        /// </summary>
        /// <returns></returns>
        public static IList<IFindRecsetOptions> FindAll()
        {
            var findRecsetOptionses = _options.Values.Where(a=>a.ArgumentCount>0).ToList();
            return findRecsetOptionses;
        }

        /// <summary>
        /// Find all AbstractRecsetSearchValidation objects
        /// </summary>
        /// <returns></returns>
        public static IList<IFindRecsetOptions> FindAllDecision() => _options.Values.ToList();
    }
}
