using System.Linq.Expressions;

namespace AspBoot.Data.Interface;

public interface IQueryableRepository<TEntity, TKey, TCount> : IRepository<TEntity, TKey, TCount>
{
    TEntity? Get(Expression<Func<TEntity, bool>> predicate);

    TEntity? Get(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, object>>[] projection);

    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, object>>[] projection);
}
