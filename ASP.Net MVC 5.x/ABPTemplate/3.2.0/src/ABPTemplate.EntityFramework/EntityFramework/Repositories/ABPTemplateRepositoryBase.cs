using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ABPTemplate.EntityFramework.Repositories
{
    public abstract class ABPTemplateRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ABPTemplateDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ABPTemplateRepositoryBase(IDbContextProvider<ABPTemplateDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ABPTemplateRepositoryBase<TEntity> : ABPTemplateRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ABPTemplateRepositoryBase(IDbContextProvider<ABPTemplateDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
