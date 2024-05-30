using AspBoot.Data.Interface;
using AspBoot.Data.Model;
using AspBoot.Data.Request;
using Microsoft.EntityFrameworkCore;

namespace AspBoot.Data.Implementation;

public class Repository<TEntity>(DbContext context) :
    CrudRepository<TEntity>(context),
    IPageableRepository<TEntity>,
    ISearchableRepository<TEntity>,
    ISortableRepository<TEntity>,
    IFilterableRepository<TEntity>
    where TEntity : class
{
    protected virtual IQueryable<TEntity> ApplyFiltering(IQueryable<TEntity> query, Filter.Predicate filter)
    {
        return query;
    }

    protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, Sort.Order order)
    {
        return query;
    }

    protected virtual IQueryable<TEntity> ApplySearch(string searchString, IQueryable<TEntity> query)
    {
        return query;
    }

    public Page<TEntity> GetPaginated(RequestPage request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null)
    {
        var queryable = Get(query);
        var total = queryable.Count();
        queryable = queryable.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var content = queryable.ToList();
        return new Page<TEntity>
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Content = content,
            TotalCount = total,
            PagesCount = (int) Math.Ceiling((double) total / request.PageSize),
            HasNext = (request.PageIndex * request.PageSize) < total,
            HasPrev = request.PageIndex > 1,
        };
    }

    public PageSearched<TEntity> Search(RequestPageSearch request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null)
    {
        var queryable = Get(query);

        queryable = ApplySearch(request.SearchString, queryable);

        var total = queryable.Count();
        queryable = queryable.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var content = queryable.ToList();
        return new PageSearched<TEntity>
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Content = content,
            TotalCount = total,
            PagesCount = (int) Math.Ceiling((double) total / request.PageSize),
            HasNext = (request.PageIndex * request.PageSize) < total,
            HasPrev = request.PageIndex > 1,
            SearchString = request.SearchString
        };
    }

    public PageSorted<TEntity> GetSorted(RequestPageSorted request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null)
    {
        var queryable = Get(query);

        queryable = request.Orders.Aggregate(queryable, ApplySorting);

        var total = queryable.Count();
        queryable = queryable.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var content = queryable.ToList();
        return new PageSorted<TEntity>
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Content = content,
            TotalCount = total,
            PagesCount = (int) Math.Ceiling((double) total / request.PageSize),
            HasNext = (request.PageIndex * request.PageSize) < total,
            HasPrev = request.PageIndex > 1,
            Orders = request.Orders
        };
    }

    public PageSortedFiltered<TEntity> GetFiltered(RequestPageSortedFiltered request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null)
    {
        var queryable = Get(query);

        queryable = request.Predicates.Aggregate(queryable, ApplyFiltering);
        queryable = request.Orders.Aggregate(queryable, ApplySorting);

        var total = queryable.Count();
        queryable = queryable.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var content = queryable.ToList();
        return new PageSortedFiltered<TEntity>
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Content = content,
            TotalCount = total,
            PagesCount = (int) Math.Ceiling((double) total / request.PageSize),
            HasNext = (request.PageIndex * request.PageSize) < total,
            HasPrev = request.PageIndex > 1,
            Orders = request.Orders,
            Predicates = request.Predicates
        };
    }
}
