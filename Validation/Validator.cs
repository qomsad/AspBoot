using FluentValidation;

namespace AspBoot.Validation;

public static class Validator
{
    public static ValidationResult<TRequest> GetValidationProblems<TRequest>(
        this IValidator<TRequest> validator,
        TRequest request) where TRequest : class
    {
        var result = validator.Validate(request);

        var problems = result.Errors.Select(error => new ValidationProblem
        {
            Property = error.PropertyName,
            Code = error.ErrorCode,
            Description = error.ErrorMessage
        });

        return new ValidationResult<TRequest>
        {
            Problems = result.IsValid ? null : problems, Request = result.IsValid ? request : null
        };
    }
}
