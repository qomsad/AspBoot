using AspBoot.Data.Model;

namespace AspBoot.Data.Request;

public class RequestPageSorted : RequestPage
{
    public IEnumerable<Sort.Order> Orders { get; init; } = [];
}
