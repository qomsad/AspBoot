namespace AspBoot.Data.Model;

public class PageSortedFiltered<TEntity> : PageSorted<TEntity>
{
    public Filter.Predicate? Predicates { get; init; }
}
