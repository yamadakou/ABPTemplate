using ABPTemplate.EntityFramework;
using EntityFramework.DynamicFilters;

namespace ABPTemplate.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly ABPTemplateDbContext _context;

        public InitialHostDbBuilder(ABPTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
