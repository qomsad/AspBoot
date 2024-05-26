using System.Linq.Expressions;
using AspBoot.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace AspBoot.Data.Implementation;

public abstract class CrudRepository<TEntity, TKey, TCount>(DbContext context)
    : ICrudRepository<TEntity, TKey, TCount>
    where TEntity : class
    where TCount : struct
{
    protected DbContext Context { get; set; } = context;
    protected DbSet<TEntity> DbSet { get; set; } = context.Set<TEntity>();

    public virtual Expression<Func<TEntity, object>>[] Projection()
    {
        return [];
    }

    public TEntity Create(TEntity entity)
    {
        var result = DbSet.Add(entity);
        Context.SaveChanges();
        return result.Entity;
    }

    public IEnumerable<TEntity> CreateAll(IEnumerable<TEntity> entities)
    {
        var enumerable = entities.ToList();
        DbSet.AddRange(enumerable);
        Context.SaveChanges();
        return enumerable;
    }

    public TEntity? Get(TEntity entity)
    {
        return WithProjection().FirstOrDefault(entity);
    }

    public IEnumerable<TEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public TEntity? GetById(TKey id)
    {
        var properties = Context.Model
            .FindEntityType(typeof(TEntity))
            ?.FindPrimaryKey()
            ?.Properties;
        var pk = properties is { Count: > 0 } ? properties[0].PropertyInfo : null;
        return WithProjection().FirstOrDefault(entity => pk!.GetValue(entity)!.Equals(id));
    }

    public TEntity Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> UpdateAll(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(TKey id)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public TCount Count()
    {
        throw new NotImplementedException();
    }

    public bool Exists(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public bool ExistsById(TKey id)
    {
        throw new NotImplementedException();
    }

    protected IQueryable<TEntity> WithProjection()
    {
        return Projection().Aggregate(DbSet.AsQueryable(), (e, property) => e.Include(property));
    }

    protected IQueryable<TEntity> WithProjection(params Expression<Func<TEntity, object>>[] projection)
    {
        return projection.Aggregate(DbSet.AsQueryable(), (e, property) => e.Include(property));
    }
}
