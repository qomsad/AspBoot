namespace AspBoot.Data.Interface;

public interface ICrudRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    public TEntity Create(TEntity entity);
    public IQueryable<TEntity> Get();
    public TEntity? Get(TEntity entity);
    public TEntity Update(TEntity entity);
    public void Delete(TEntity entity);
}
