using System.Security.Cryptography;

using Mansis.Pos.Application.Auth;

namespace Mansis.Pos.Infrastructure.Auth;

internal sealed class HmacPasswordVerifier : IPasswordVerifier
{
    private const int LegacyHashLength = 64;
    private const int LegacySaltLength = 128;

    public bool Verify(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        if (string.IsNullOrWhiteSpace(password)
            || passwordHash.Length != LegacyHashLength
            || passwordSalt.Length != LegacySaltLength)
        {
            return false;
        }

        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return CryptographicOperations.FixedTimeEquals(computedHash, passwordHash);
    }
}
