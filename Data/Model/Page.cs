namespace AspBoot.Data.Model;

public class Page<TEntity>
{
    public required int PageIndex { get; init; }
    public required int PageSize { get; init; }

    public required IEnumerable<TEntity> Content { get; init; }

    public required int TotalCount { get; init; }
    public required int PagesCount { get; init; }

    public bool HasNext { get; init; }
    public bool HasPrev { get; init; }
}
