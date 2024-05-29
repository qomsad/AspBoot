namespace AspBoot.Validation;

public class ValidationResult<TResult>
    where TResult : class
{
    public IEnumerable<ValidationProblem>? Problems { get; init; }
    public TResult? Request { get; init; }
}

public class ValidationProblem
{
    public required string Property { get; set; }
    public required string Code { get; set; }
    public required string Description { get; set; }
}
