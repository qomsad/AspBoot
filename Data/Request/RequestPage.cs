namespace AspBoot.Data.Request;

public class RequestPage
{
    public int PageIndex { get; init; } = 1;

    public int PageSize { get; set; } = 10;
}
