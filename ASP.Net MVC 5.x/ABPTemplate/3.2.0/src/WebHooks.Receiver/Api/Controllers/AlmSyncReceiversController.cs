using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Controllers;
using Microsoft.AspNet.WebHooks.Routes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebHooks.Receiver.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [RoutePrefix("api/sync")]
    public class AlmSyncReceiversController : WebHookReceiversController
    {
        private const string c_WebHookReceiverRouteNames_AlmSyncReceiversAction = "AlmSyncReceiversAction";
        /// <summary>
        /// Supports GET for incoming WebHook request. This is typically used to verify that a WebHook is correctly wired up.
        /// </summary>
        [Route("{webHookReceiver}/{id?}", Name = c_WebHookReceiverRouteNames_AlmSyncReceiversAction)]
        [AllowAnonymous]
        [SuppressMessage("Microsoft.Design", "CA1026:Default parameters should not be used", Justification = "This is an established parameter binding pattern for Web API.")]
        public new Task<IHttpActionResult> Get(string webHookReceiver, string id = "")
        {
            return ProcessWebHook(webHookReceiver, id);
        }

        /// <summary>
        /// Supports HEAD for incoming WebHook request. This is typically used to verify that a WebHook is correctly wired up.
        /// </summary>
        [Route("{webHookReceiver}/{id?}")]
        [AllowAnonymous]
        [SuppressMessage("Microsoft.Design", "CA1026:Default parameters should not be used", Justification = "This is an established parameter binding pattern for Web API.")]
        public new Task<IHttpActionResult> Head(string webHookReceiver, string id = "")
        {
            return ProcessWebHook(webHookReceiver, id);
        }

        /// <summary>
        /// Supports POST for incoming WebHook requests. This is typically the actual WebHook.
        /// </summary>
        [Route("{webHookReceiver}/{id?}")]
        [AllowAnonymous]
        [SuppressMessage("Microsoft.Design", "CA1026:Default parameters should not be used", Justification = "This is an established parameter binding pattern for Web API.")]
        public new Task<IHttpActionResult> Post(string webHookReceiver, string id = "")
        {
            return ProcessWebHook(webHookReceiver, id);
        }

        private async Task<IHttpActionResult> ProcessWebHook(string webHookReceiver, string id)
        {
            IWebHookReceiverManager receiverManager = Configuration.DependencyResolver.GetReceiverManager();
            IWebHookReceiver receiver = receiverManager.GetReceiver(webHookReceiver);
            if (receiver == null)
            {
                string msg = string.Format(CultureInfo.CurrentCulture, @"No WebHook receiver is registered with the name '{0}'.", webHookReceiver);
                Configuration.DependencyResolver.GetLogger().Error(msg);
                return NotFound();
            }

            try
            {
                string msg = string.Format(CultureInfo.CurrentCulture, @"Processing incoming WebHook request with receiver '{0}' and id '{1}'.", webHookReceiver, id);
                Configuration.DependencyResolver.GetLogger().Info(msg);
                HttpResponseMessage response = await receiver.ReceiveAsync(id, RequestContext, Request);
                return ResponseMessage(response);
            }
            catch (HttpResponseException rex)
            {
                return ResponseMessage(rex.Response);
            }
            catch (Exception ex)
            {
                Exception inner = ex.GetBaseException();
                string msg = string.Format(CultureInfo.CurrentCulture, @"WebHook receiver '{0}' could not process WebHook due to error: {1}", webHookReceiver, inner.Message);
                Configuration.DependencyResolver.GetLogger().Error(msg, inner);
                throw;
            }
        }
    }
}
