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
using Warewolf.Options;

namespace Warewolf.Data.Decisions.Operations
{
    public class Dev2DecisionFactory : SpookyAction<IDecisionOperation, Enum>
    {
        static Dev2DecisionFactory _inst;

        public static Dev2DecisionFactory Instance()
        {
            return _inst ?? (_inst = new Dev2DecisionFactory());
        }

        public IDecisionOperation FetchDecisionFunction(EnDecisionType typeOf) => FindMatch(typeOf);
    }
}
