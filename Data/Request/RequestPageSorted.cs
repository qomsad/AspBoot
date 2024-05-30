using AspBoot.Data.Model;

namespace AspBoot.Data.Request;

public class RequestPageSorted : RequestPage
{
    public Sort.Order? Orders { get; init; }
}
