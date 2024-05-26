using System.Linq.Expressions;

namespace AspBoot.Data.Interface;

public interface IRepository<TEntity, TKey, TCount>
{
    public Expression<Func<TEntity, object>>[] Projection();
}
