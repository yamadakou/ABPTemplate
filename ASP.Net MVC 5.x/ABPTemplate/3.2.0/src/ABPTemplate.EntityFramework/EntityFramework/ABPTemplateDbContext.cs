﻿using System.Data.Common;
using Abp.Zero.EntityFramework;
using ABPTemplate.Authorization.Roles;
using ABPTemplate.Authorization.Users;
using ABPTemplate.MultiTenancy;

namespace ABPTemplate.EntityFramework
{
    public class ABPTemplateDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ABPTemplateDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ABPTemplateDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ABPTemplateDbContext since ABP automatically handles it.
         */
        public ABPTemplateDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ABPTemplateDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public ABPTemplateDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
