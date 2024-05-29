using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace AspBoot.Handler;

public class HttpResult
{
    public static IActionResult Ok(object? result)
    {
        return new ObjectResult(result) { StatusCode = (int?) HttpStatusCode.OK };
    }

    public static IActionResult Unauthorized(object? result)
    {
        return new ObjectResult(result) { StatusCode = (int?) HttpStatusCode.Unauthorized };
    }

    public static IActionResult NotFound(object? result)
    {
        return new ObjectResult(result) { StatusCode = (int?) HttpStatusCode.NotFound };
    }

    public static IActionResult Conflict(object? result)
    {
        return new ObjectResult(result) { StatusCode = (int?) HttpStatusCode.Conflict };
    }

    public static IActionResult Forbidden(object? result)
    {
        return new ObjectResult(result) { StatusCode = (int?) HttpStatusCode.Forbidden };
    }

    public static IActionResult ValidationProblem(object? result)
    {
        return new ObjectResult(result) { StatusCode = (int?) HttpStatusCode.BadRequest };
    }

    public static IActionResult InternalServerError(object? result)
    {
        return new ObjectResult(result) { StatusCode = (int?) HttpStatusCode.InternalServerError };
    }
}
