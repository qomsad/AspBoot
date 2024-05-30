using AspBoot.Data.Model;
using AspBoot.Data.Request;

namespace AspBoot.Data.Interface;

public interface ISortableRepository<TEntity> : IRepository<TEntity>
{
    PageSorted<TEntity> GetSorted(RequestPageSorted request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null);
}
