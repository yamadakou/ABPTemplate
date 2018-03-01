using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using ABPTemplate.EntityFramework;

namespace ABPTemplate
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(ABPTemplateCoreModule))]
    public class ABPTemplateDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ABPTemplateDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
