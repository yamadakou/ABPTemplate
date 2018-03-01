using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPTemplate.Configuration;

namespace ABPTemplate.Web.Host.Startup
{
    [DependsOn(
       typeof(ABPTemplateWebCoreModule))]
    public class ABPTemplateWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ABPTemplateWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ABPTemplateWebHostModule).GetAssembly());
        }
    }
}
