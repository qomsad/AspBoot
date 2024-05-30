using AspBoot.Data.Model;
using AspBoot.Data.Request;

namespace AspBoot.Data.Interface;

public interface IPageableRepository<TEntity> : IRepository<TEntity>
{
    Page<TEntity> GetPaginated(RequestPage request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null);
}
