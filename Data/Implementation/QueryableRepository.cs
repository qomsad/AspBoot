using System.Linq.Expressions;
using AspBoot.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspBoot.Data.Implementation;

public class QueryableRepository<TEntity, TKey, TCount>(DbContext context)
    : CrudRepository<TEntity, TKey, TCount>(context), IQueryableRepository<TEntity, TKey, TCount>
    where TEntity : class
    where TCount : struct
{
    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        return WithProjection().FirstOrDefault(predicate);
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, object>>[] projection)
    {
        return WithProjection(projection).FirstOrDefault(predicate);
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
    {
        return WithProjection().Where(predicate);
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, object>>[] projection)
    {
        return WithProjection(projection).Where(predicate);
    }
}
