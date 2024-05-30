using AspBoot.Data.Model;
using AspBoot.Data.Request;

namespace AspBoot.Data.Interface;

public interface ISearchableRepository<TEntity> : IRepository<TEntity>
{
    PageSearched<TEntity> Search(RequestPageSearch request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null);
}
