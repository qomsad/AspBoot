namespace AspBoot.Data.Interface;

public interface ICrudRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public TEntity Create(TEntity entity);
    public IQueryable<TEntity> Get();
    public TEntity Update(TEntity entity);
    public void Delete(TEntity entity);
}
