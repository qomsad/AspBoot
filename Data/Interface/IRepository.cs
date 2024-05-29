namespace AspBoot.Data.Interface;

public interface IRepository<TEntity, TKey>
{
    public IQueryable<TEntity> Projection(IQueryable<TEntity> query);
}
