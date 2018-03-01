using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ABPTemplate.EntityFrameworkCore
{
    public static class ABPTemplateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ABPTemplateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ABPTemplateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
