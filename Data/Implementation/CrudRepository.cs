using AspBoot.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspBoot.Data.Implementation;

public abstract class CrudRepository<TEntity>(DbContext context) : ICrudRepository<TEntity> where TEntity : class
{
    protected DbContext Context { get; } = context;
    protected DbSet<TEntity> DbSet { get; } = context.Set<TEntity>();

    public virtual IQueryable<TEntity> Projection(IQueryable<TEntity> query)
    {
        return query;
    }

    public TEntity Create(TEntity entity)
    {
        DbSet.Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public IQueryable<TEntity> Get()
    {
        return Projection(DbSet.AsQueryable());
    }

    public TEntity? Get(TEntity entity)
    {
        return Get().FirstOrDefault(entity);
    }

    public IQueryable<TEntity> Get(Func<IQueryable<TEntity>, IQueryable<TEntity>>? query)
    {
        return query != null ? query(Get()) : Get();
    }

    public TEntity Update(TEntity entity)
    {
        DbSet.Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
        Context.SaveChanges();
    }
}
