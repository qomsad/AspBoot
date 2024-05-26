namespace AspBoot.Data.Interface;

public interface ICrudRepository<TEntity, TKey, TCount> : IRepository<TEntity, TKey, TCount>
    where TEntity : class
    where TCount : struct
{
    TEntity Create(TEntity entity);
    IEnumerable<TEntity> CreateAll(IEnumerable<TEntity> entities);

    TEntity? Get(TEntity entity);
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(TKey id);

    TEntity Update(TEntity entity);
    IEnumerable<TEntity> UpdateAll(IEnumerable<TEntity> entities);

    void DeleteById(TKey id);
    void Delete(TEntity entity);

    TCount Count();

    bool Exists(TEntity entity);
    bool ExistsById(TKey id);
}
