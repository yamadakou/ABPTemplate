using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using ABPTemplate.EntityFramework;

namespace ABPTemplate.Migrator
{
    [DependsOn(typeof(ABPTemplateDataModule))]
    public class ABPTemplateMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<ABPTemplateDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}