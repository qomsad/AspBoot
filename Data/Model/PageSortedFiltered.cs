namespace AspBoot.Data.Model;

public class PageSortedFiltered<TEntity> : PageSorted<TEntity>
{
    public IEnumerable<Filter.Predicate> Predicates { get; init; } = [];
}
