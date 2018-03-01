using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ABPTemplate.Authorization.Roles;
using ABPTemplate.Authorization.Users;
using ABPTemplate.MultiTenancy;

namespace ABPTemplate.EntityFrameworkCore
{
    public class ABPTemplateDbContext : AbpZeroDbContext<Tenant, Role, User, ABPTemplateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ABPTemplateDbContext(DbContextOptions<ABPTemplateDbContext> options)
            : base(options)
        {
        }
    }
}
