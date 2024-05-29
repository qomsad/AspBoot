using System.Security.Claims;

namespace AspBoot.Auth;

public static class AuthExtensions
{
    public static string? GetPrincipal(this ClaimsPrincipal principal, string type)
    {
        return principal.Claims.FirstOrDefault(claim => claim.Type == type)?.Value;
    }
}
