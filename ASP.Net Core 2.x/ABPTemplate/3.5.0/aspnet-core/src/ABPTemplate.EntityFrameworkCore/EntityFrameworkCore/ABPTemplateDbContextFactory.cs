using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ABPTemplate.Configuration;
using ABPTemplate.Web;

namespace ABPTemplate.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ABPTemplateDbContextFactory : IDesignTimeDbContextFactory<ABPTemplateDbContext>
    {
        public ABPTemplateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ABPTemplateDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ABPTemplateDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ABPTemplateConsts.ConnectionStringName));

            return new ABPTemplateDbContext(builder.Options);
        }
    }
}
