using AspBoot.Data.Model;
using AspBoot.Data.Request;

namespace AspBoot.Data.Interface;

public interface ISearchableRepository<TEntity, TKey> : IRepository<TEntity, TKey>
{
    PageSearched<TEntity> Search(RequestPageSearch request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null);
}
