using AspBoot.Data.Model;

namespace AspBoot.Data.Request;

public class RequestPageSortedFiltered : RequestPageSorted
{
    public IEnumerable<Filter.Predicate> Predicates { get; init; } = [];
}
