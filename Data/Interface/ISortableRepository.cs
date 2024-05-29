using AspBoot.Data.Model;
using AspBoot.Data.Request;

namespace AspBoot.Data.Interface;

public interface ISortableRepository<TEntity, TKey> : IRepository<TEntity, TKey>
{
    PageSorted<TEntity> GetSorted(RequestPageSorted request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null);
}
