using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Microsoft.AspNet.WebHooks.Controllers;
using WebHooks.Receiver.Api.Controllers;
using WebHooks.Receiver.Api.WebHooks;

namespace WebHooks.Receiver.Api
{
    [DependsOn(typeof(AbpWebApiModule))]
    public class WebHooksApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // Web API routes
            Configuration.Modules.AbpWebApi().HttpConfiguration.MapHttpAttributeRoutes();

            Configuration.Modules.AbpWebApi().HttpConfiguration.InitializeReceiveGenericJsonWebHooks();

            // GenericJsonの場合
            //Configuration.Modules.AbpWebApi().HttpConfiguration.InitializeReceiveGenericJsonWebHooks();

            // Customの場合
            //Configuration.Modules.AbpWebApi().HttpConfiguration.InitializeReceiveCustomWebHooks();
        }
    }
}
