using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using Castle.Core.Logging;
using Abp.Logging;
using System.Collections.Specialized;
using System.Net.Http;

namespace WebHooks.Receiver.Api.WebHooks
{
    public class WorkItemsWebHookHandler : WebHookHandler
    {
        public WorkItemsWebHookHandler()
        {
            this.Receiver = WorkItemsWebHookReceiver.ReceiverName;
        }

        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            // Get JSON from WebHook
            JObject data = context.GetDataOrDefault<JObject>();

            // Get the action for this WebHook coming from the action query parameter in the URI
            string action = context.Actions.FirstOrDefault();

            // Get query parameter in the URI
            var queryParameters = context.Request.RequestUri.ParseQueryString();
            string key = null;
            if (queryParameters.AllKeys.Any(k => k == "key"))
            {
                key = queryParameters["key"];
            }
            LogHelper.Logger.DebugFormat("key={0}", key);
            LogHelper.Logger.DebugFormat("data={0}", data);
            LogHelper.Logger.DebugFormat("action={0}", action);
            LogHelper.Logger.DebugFormat("queryParameters={0}", queryParameters);

            return Task.FromResult(true);
        }
    }
}
