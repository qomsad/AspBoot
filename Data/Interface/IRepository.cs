namespace AspBoot.Data.Interface;

public interface IRepository<TEntity>
{
    public IQueryable<TEntity> Projection(IQueryable<TEntity> query);
}
