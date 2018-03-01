using System.Linq;
using ABPTemplate.EntityFramework;
using ABPTemplate.MultiTenancy;

namespace ABPTemplate.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly ABPTemplateDbContext _context;

        public DefaultTenantCreator(ABPTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
