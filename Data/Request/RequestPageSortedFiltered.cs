using AspBoot.Data.Model;

namespace AspBoot.Data.Request;

public class RequestPageSortedFiltered : RequestPageSorted
{
    public Filter.Predicate? Predicates { get; init; }
}
