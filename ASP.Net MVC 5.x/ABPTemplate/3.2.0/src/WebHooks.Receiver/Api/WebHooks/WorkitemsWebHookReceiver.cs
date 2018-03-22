using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace Microsoft.AspNet.WebHooks
{
    public class WorkItemsWebHookReceiver : WebHookReceiver
    {
        internal const string RecName = "workitems";
        internal const string ActionQueryParameter = "action";
        internal const string DefaultAction = "change";

        public static string ReceiverName
        {
            get { return RecName; }
        }

        /// <inheritdoc />
        public override string Name
        {
            get { return RecName; }
        }

        public override async Task<HttpResponseMessage> ReceiveAsync(string id, HttpRequestContext context, HttpRequestMessage request)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Method != HttpMethod.Post)
            {
                return CreateBadMethodResponse(request);
            }

            // Ensure that we use https and have a valid code parameter
            await EnsureValidCode(request, id);

            // Read the request entity body
            JToken data = await ReadAsJsonTokenAsync(request);

            // Get the action
            NameValueCollection queryParameters = request.RequestUri.ParseQueryString();
            string action = queryParameters[ActionQueryParameter];
            if (string.IsNullOrEmpty(action))
            {
                action = DefaultAction;
            }

            // Call registered handlers
            return await ExecuteWebHookAsync(id, context, request, new[] { action }, data);

        }
    }
}
