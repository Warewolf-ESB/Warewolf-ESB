﻿#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2021 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common;
using Dev2.Common.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Common.Interfaces.Core.Graph;
using Dev2.Common.Interfaces.DB;
using Dev2.Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Warewolf.Core;
using Warewolf.Security.Encryption;

namespace Dev2.Runtime.ServiceModel.Data
{
    public class WcfSource : Resource, IWcfSource
    {
        public string EndpointUrl { get; set; }
        public string ContactName { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Path { get; set; }
        public enSourceType Type { get; set; }
        readonly IWcfProxyService ProxyService;

        public WcfSource()
        {
            ResourceID = Guid.Empty;
            ResourceType = "WcfSource";

            ProxyService = new WcfProxyService();
        }

        public WcfSource(IWcfProxyService service)
        {
            ResourceID = Guid.Empty;
            ResourceType = "WcfSource";

            ProxyService = service;
        }

        public WcfSource(XElement xml)
            : base(xml)
        {
            ResourceType = "WcfSource";
            ProxyService = new WcfProxyService();
            var properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "EndpointUrl", string.Empty },
            };

            var conString = xml.AttributeSafe("ConnectionString");
            var connectionString = conString.CanBeDecrypted() ? SecurityEncryption.Decrypt(conString) : conString;
            ParseProperties(connectionString, properties);

            EndpointUrl = properties["EndpointUrl"];
        }

        public void Execute()
        {
            GetServiceMethods(EndpointUrl);
        }

        public Dictionary<MethodInfo, ParameterInfo[]> GetServiceMethods(string endpoint) => ProxyService.GetMethods(endpoint);

        public IList<IWcfAction> GetServiceActions(IWcfServerSource source)
        {
            var methods = GetServiceMethods(source.EndpointUrl);
            var actionList = new List<IWcfAction>();
            foreach (var method in methods)
            {
                var action = new WcfAction
                {
                    FullName = method.Key.Name,
                    Method = method.Key.Name,
                    Inputs = new List<IServiceInput>()
                };

                foreach (var paramater in method.Value)
                {
                    action.Inputs.Add(new ServiceInput
                    {
                        Name = paramater.Name,
                        TypeName = paramater.ParameterType.FullName
                    });
                }

                actionList.Add(action);
            }
            return actionList;
        }

        public IOutputDescription ExecuteMethod(WcfService src) => ProxyService.ExecuteWebService(src);

        public object ExecuteMethod(IWcfAction action) => ProxyService.ExcecuteMethod(action, EndpointUrl);

        #region ToXml

        public override XElement ToXml()
        {
            var result = base.ToXml();
            var connectionString = string.Join(";",
                string.Format("EndpointUrl={0}", EndpointUrl)
                );

            result.Add(
                new XAttribute("ConnectionString", SecurityEncryption.Encrypt(connectionString)),
                new XAttribute("Type", ResourceType),
                new XElement("TypeOf", ResourceType)
                );

            return result;
        }

        #endregion ToXml

        public new string DataList
        {
            get
            {
                var stringBuilder = base.DataList;
                return stringBuilder?.ToString();
            }
            set
            {
                base.DataList = value.ToStringBuilder();
            }
        }

        public bool Equals(IWcfSource other) => true;
    }

    public class ServiceModel
    {
        public string MethodName { get; set; }
        public Dictionary<MethodInfo, ParameterInfo[]> ParamsList { get; set; }
    }
}