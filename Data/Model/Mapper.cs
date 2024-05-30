namespace AspBoot.Data.Model;

public static class Mapper
{
    public static Page<TTo> MapPage<TFrom, TTo>(this Page<TFrom> from,
        Func<object, IEnumerable<TTo>> mapper)
    {
        return new Page<TTo>
        {
            PageIndex = from.PageIndex,
            PageSize = from.PageSize,
            Content = mapper(from.Content),
            TotalCount = from.TotalCount,
            PagesCount = from.PagesCount,
            HasNext = from.HasNext,
            HasPrev = from.HasPrev,
        };
    }

    public static PageSearched<TTo> MapPageSearched<TFrom, TTo>(this PageSearched<TFrom> from,
        Func<object, IEnumerable<TTo>> mapper)
    {
        return new PageSearched<TTo>
        {
            PageIndex = from.PageIndex,
            PageSize = from.PageSize,
            Content = mapper(from.Content),
            TotalCount = from.TotalCount,
            PagesCount = from.PagesCount,
            HasNext = from.HasNext,
            HasPrev = from.HasPrev,
            SearchString = from.SearchString
        };
    }

    public static PageSorted<TTo> MapPageSorted<TFrom, TTo>(this PageSorted<TFrom> from,
        Func<object, IEnumerable<TTo>> mapper)
    {
        return new PageSorted<TTo>
        {
            PageIndex = from.PageIndex,
            PageSize = from.PageSize,
            Content = mapper(from.Content),
            TotalCount = from.TotalCount,
            PagesCount = from.PagesCount,
            HasNext = from.HasNext,
            HasPrev = from.HasPrev,
            Orders = from.Orders
        };
    }

    public static PageSortedFiltered<TTo> MapPageSortedFiltered<TFrom, TTo>(this PageSortedFiltered<TFrom> from,
        Func<object, IEnumerable<TTo>> mapper)
    {
        return new PageSortedFiltered<TTo>
        {
            PageIndex = from.PageIndex,
            PageSize = from.PageSize,
            Content = mapper(from.Content),
            TotalCount = from.TotalCount,
            PagesCount = from.PagesCount,
            HasNext = from.HasNext,
            HasPrev = from.HasPrev,
            Orders = from.Orders,
            Predicates = from.Predicates
        };
    }
}
