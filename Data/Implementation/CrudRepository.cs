using AspBoot.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspBoot.Data.Implementation;

public abstract class CrudRepository<TEntity, TKey>(DbContext context) : ICrudRepository<TEntity, TKey>
    where TEntity : class
{
    protected DbContext Context { get; set; } = context;
    protected DbSet<TEntity> DbSet { get; set; } = context.Set<TEntity>();

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

    public IQueryable<TEntity> Get(Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null)
    {
        return query != null
            ? query(DbSet.AsQueryable())
            : Projection(DbSet.AsQueryable());
    }

    public TEntity? GetById(TKey id)
    {
        var properties = Context.Model
            .FindEntityType(typeof(TEntity))
            ?.FindPrimaryKey()
            ?.Properties;
        var pk = properties is { Count: > 0 } ? properties[0].PropertyInfo : null;
        return Projection(DbSet.AsQueryable()).FirstOrDefault(entity => pk!.GetValue(entity)!.Equals(id));
    }

    public TEntity? GetOne(TEntity entity)
    {
        return Get().FirstOrDefault(e => e == entity);
    }

    public TEntity? GetOne(Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null)
    {
        return Get(query).FirstOrDefault();
    }

    public IEnumerable<TEntity>? GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null)
    {
        return Get(query).ToList();
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

    public void DeleteById(TKey id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            Delete(entity);
        }
    }
}
