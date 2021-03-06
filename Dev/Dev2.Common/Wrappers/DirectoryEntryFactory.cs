﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common.Interfaces.Wrappers;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;

namespace Dev2.Common.Wrappers
{
    public class DirectoryEntryFactory : IDirectoryEntryFactory
    {
        public IDirectoryEntry Create(string path)
        {
            return new Dev2DirectoryEntry(path);
        }
        [ExcludeFromCodeCoverage]
        public IDirectoryEntry Create<T>(T member)
        {
            return new Dev2DirectoryEntry(new DirectoryEntry(member));
        }
    }
}
