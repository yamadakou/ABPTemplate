using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABPTemplate.Authorization;

namespace ABPTemplate
{
    [DependsOn(
        typeof(ABPTemplateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ABPTemplateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ABPTemplateAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ABPTemplateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
