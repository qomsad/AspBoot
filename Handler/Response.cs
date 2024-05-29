using AspBoot.Validation;
using Microsoft.AspNetCore.Mvc;

namespace AspBoot.Handler;

public class Response<TRequest, TStatus>
    where TRequest : class
    where TStatus : Enum
{
    private ValidationResult<TRequest>? valid;
    private Func<TRequest, Result<TStatus>>? handler;
    private readonly Dictionary<TStatus, Func<object?, IActionResult>> actions = new();

    private Func<object?, IActionResult> invalid = HttpResult.ValidationProblem;
    private Func<object?, IActionResult> present = HttpResult.Ok;
    private Func<object?, IActionResult> unknown = HttpResult.InternalServerError;

    public Response<TRequest, TStatus> OnValidationError(
        ValidationResult<TRequest> validation, Func<object?, IActionResult> cb)
    {
        invalid = cb;
        valid = validation;
        return this;
    }

    public Response<TRequest, TStatus> Handle(Func<TRequest, Result<TStatus>> service)
    {
        handler = service;
        return this;
    }

    public Response<TRequest, TStatus> OnPresent(Func<object?, IActionResult> cb)
    {
        present = cb;
        return this;
    }

    public Response<TRequest, TStatus> OnStatus(TStatus status, Func<object?, IActionResult> cb)
    {
        actions.TryAdd(status, cb);
        return this;
    }

    public Response<TRequest, TStatus> OnUnknown(Func<object?, IActionResult> cb)
    {
        unknown = cb;
        return this;
    }

    public Response<TRequest, TStatus> WhenPresent(Func<IActionResult> cb)
    {
        present = _ => cb();
        return this;
    }

    public Response<TRequest, TStatus> WhenStatus(TStatus status, Func<IActionResult> cb)
    {
        actions.TryAdd(status, _ => cb());
        return this;
    }

    public Response<TRequest, TStatus> WhenUnknown(Func<IActionResult> cb)
    {
        unknown = _ => cb();
        return this;
    }

    public IActionResult Respond()
    {
        Result<TStatus>? result = null;

        if (valid == null)
        {
            result = handler?.Invoke(null!);
        }

        else if (valid.Problems != null)
        {
            return invalid(valid.Problems);
        }

        else if (valid.Request != null)
        {
            result = handler?.Invoke(valid.Request);
        }


        if (result is { Value: not null, Status: null })
        {
            return present(result.Value);
        }

        foreach (var action in actions)
        {
            if (result?.Status != null && action.Key.Equals(result.Status.Code))
            {
                return action.Value(result.Status);
            }
        }

        var message = actions.Select(kv => ($"{kv.Key}")).ToList();
        return unknown($"[{String.Join(",\n", message)}]");
    }
}
