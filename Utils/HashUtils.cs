using System.Security.Cryptography;
using System.Text;

namespace AspBoot.Utils;

public static class HashUtils
{
    public static (string, string) GeneratePasswordHash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = SHA256.HashData(Encoding.ASCII.GetBytes(password).Concat(salt).ToArray());
        return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
    }

    public static bool VerifyPassword(string password, string passwordHash, string passwordSalt)
    {
        var salt = Convert.FromBase64String(passwordSalt);
        var hash = Convert.FromBase64String(passwordHash);
        var actual = SHA256.HashData(Encoding.ASCII.GetBytes(password).Concat(salt).ToArray());
        return hash.SequenceEqual(actual);
    }
}
