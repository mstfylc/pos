using System.Security.Cryptography;

using Mansis.Pos.Application.Auth;

namespace Mansis.Pos.Infrastructure.Auth;

internal sealed class HmacPasswordVerifier : IPasswordVerifier
{
    public bool Verify(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        if (passwordHash.Length == 0 || passwordSalt.Length == 0)
        {
            return false;
        }

        // TODO: verify rule (eski davranis: legacy password hash algoritmasi HMACSHA512 varsayildi).
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return CryptographicOperations.FixedTimeEquals(computedHash, passwordHash);
    }
}
