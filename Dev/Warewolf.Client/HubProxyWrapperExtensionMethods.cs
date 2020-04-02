﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2020 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Threading.Tasks;
using Dev2.Communication;
using Dev2.SignalR.Wrappers;
using Warewolf.Esb;

namespace Warewolf.Client
{
    public static class HubProxyWrapperExtensionMethods
    {
        public static Task<T> ExecReq3<T>(this IConnectedHubProxy connectedProxy, ICatalogRequest request, int maxRetries)
        {
            return Task<T>.Factory.StartNew(() => {
                int tries = 0;
                do
                {
                    try
                    {
                        connectedProxy.Connection.EnsureConnected(TimeSpan.FromSeconds(5)).Wait();

                        return connectedProxy.Proxy.ExecReq2<T>(request)
                            .ContinueWith((resultTask) =>
                            {
                                if (resultTask.IsFaulted)
                                {
                                    throw resultTask.Exception;
                                }

                                return resultTask.Result;
                            }).Result;
                    }
                    catch (InvalidOperationException e)
                    {
                        tries++;
                        if (tries >= maxRetries)
                        {
                            throw e;
                        }
                    }
                } while (tries <= maxRetries);

                throw new Exception("max retries reached");
            });
        }
        public static Task<T> ExecReq2<T>(this IHubProxyWrapper proxy, ICatalogRequest request)
        {
            var serializer = new Dev2JsonSerializer();
            var deployEnvelope = new Envelope
            {
                Content = serializer.Serialize(request.Build()),
                PartID = 0,
                Type = typeof(Envelope)
            };
            var messageId = Guid.NewGuid();
            return proxy.Invoke<Receipt>("ExecuteCommand", deployEnvelope, true, Guid.Empty, Guid.Empty, messageId)
                .ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        return default;
                    }
                    return proxy.Invoke<string>("FetchExecutePayloadFragment", new FutureReceipt {PartID = 0, RequestID = messageId})
                        .ContinueWith((task1) =>
                        {
                            var payload = task1.Result;
                            return serializer.Deserialize<T>(payload);
                        }).Result;
                });
        }

        public static HubWatcher<T> Watch<T>(this IConnectedHubProxy proxy, ICatalogSubscribeRequest request)
        {
            return proxy.Proxy.Watch<T>(request);
        }
        public static HubWatcher<T> Watch<T>(this IHubProxyWrapper proxy, ICatalogSubscribeRequest request)
        {
            return new HubWatcher<T>(proxy, request);
        }
    }
}