namespace AspBoot.Data.Interface;

public interface ICrudRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    public TEntity Create(TEntity entity);
    public IQueryable<TEntity> Get(Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null);
    public TEntity? GetById(TKey id);
    public TEntity Update(TEntity entity);
    public void Delete(TEntity entity);
}
