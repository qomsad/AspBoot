using Microsoft.AspNetCore.Mvc;

namespace AspBoot.Handler;

public class Result<T, TEnum>
    where T : class
    where TEnum : Enum
{
    public T? Value { get; }
    public Status<TEnum>? Status { get; }

    private Func<object?, IActionResult> present = value => new OkObjectResult(value);
    private Func<IActionResult> unknown = () => new StatusCodeResult(500);
    private readonly Dictionary<TEnum, Func<object?, IActionResult>> functions = new();
    private readonly Dictionary<TEnum, Func<IActionResult>> suppliers = new();

    public Result(TEnum code)
    {
        Value = null;
        Status = new Status<TEnum>(code);
    }

    public Result(T? value)
    {
        Value = value;
    }

    public Result<T, TEnum> OnPresent(Func<object?, IActionResult> cb)
    {
        present = cb;
        return this;
    }

    public Result<T, TEnum> OnStatus(TEnum code, Func<object?, IActionResult> cb)
    {
        if (!(functions.ContainsKey(code) || functions.ContainsValue(cb)))
        {
            functions.Add(code, cb);
        }

        return this;
    }

    public Result<T, TEnum> WhenStatus(TEnum code, Func<IActionResult> cb)
    {
        if (!(suppliers.ContainsKey(code) || suppliers.ContainsValue(cb)))
        {
            suppliers.Add(code, cb);
        }

        return this;
    }

    public Result<T, TEnum> OnUnknown(Func<IActionResult> cb)
    {
        unknown = cb;
        return this;
    }

    public IActionResult Respond()
    {
        if (Value != null && Status == null)
        {
            return present(Value);
        }

        foreach (var function in functions)
        {
            if (Status != null && function.Key.Equals(Status.Code))
            {
                return function.Value(Status);
            }
        }

        foreach (var supplier in suppliers)
        {
            if (Status != null && supplier.Key.Equals(Status.Code))
            {
                return supplier.Value();
            }
        }

        return unknown();
    }
}
