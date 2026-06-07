using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using Mansis.Pos.Application.Auth;

namespace Mansis.Pos.Infrastructure.Auth;

internal sealed class Argon2idPasswordHasher : IPasswordHasher
{
    private const int SaltLength = 16;
    private const int HashLength = 32;
    private const int DegreeOfParallelism = 2;
    private const int Iterations = 3;
    private const int MemorySize = 65536;

    public PasswordHashResult Hash(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password is required.", nameof(password));
        }

        var salt = RandomNumberGenerator.GetBytes(SaltLength);
        var hash = ComputeHash(password, salt);
        var encoded = $"$argon2id$v=19$m={MemorySize},t={Iterations},p={DegreeOfParallelism}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
        return new PasswordHashResult(Encoding.UTF8.GetBytes(encoded), []);
    }

    public bool Verify(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        if (string.IsNullOrWhiteSpace(password) || passwordHash.Length == 0)
        {
            return false;
        }

        var encoded = Encoding.UTF8.GetString(passwordHash);
        var parts = encoded.Split('$', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 5 || parts[0] != "argon2id" || parts[1] != "v=19")
        {
            return false;
        }

        var parameters = parts[2]
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(part => part.Split('=', 2))
            .ToDictionary(part => part[0], part => int.Parse(part[1]));

        var salt = Convert.FromBase64String(parts[3]);
        var expectedHash = Convert.FromBase64String(parts[4]);
        var computedHash = ComputeHash(
            password,
            salt,
            parameters["m"],
            parameters["t"],
            parameters["p"],
            expectedHash.Length);

        return CryptographicOperations.FixedTimeEquals(computedHash, expectedHash);
    }

    private static byte[] ComputeHash(
        string password,
        byte[] salt,
        int memorySize = MemorySize,
        int iterations = Iterations,
        int degreeOfParallelism = DegreeOfParallelism,
        int hashLength = HashLength)
    {
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = degreeOfParallelism,
            Iterations = iterations,
            MemorySize = memorySize
        };

        return argon2.GetBytes(hashLength);
    }
}
