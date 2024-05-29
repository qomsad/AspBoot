namespace AspBoot.Handler;

public class Result<TStatus> where TStatus : Enum
{
    public object? Value { get; }
    public Status<TStatus>? Status { get; }

    public Result(TStatus code)
    {
        Status = new Status<TStatus>(code);
    }

    public Result(object value)
    {
        Value = value;
    }
}
