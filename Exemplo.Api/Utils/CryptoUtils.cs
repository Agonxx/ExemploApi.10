using System;
using System.Security.Cryptography;

namespace Exemplo.Api.Utils
{
    public static class CryptoUtils
    {
        private const int SaltSize = 16; // bytes
        private const int HashSize = 32; // bytes
        private const int Iterations = 100_000;

        // Gera um hash combinado no formato: {iterations}.{saltBase64}.{hashBase64}
        public static string HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(HashSize);

            var saltB64 = Convert.ToBase64String(salt);
            var hashB64 = Convert.ToBase64String(hash);

            return $"{Iterations}.{saltB64}.{hashB64}";
        }

        // Verifica a senha contra o hash armazenado (no formato gerado por HashPassword)
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(storedHash))
                return false;

            var parts = storedHash.Split('.', 3);
            if (parts.Length != 3) return false;

            if (!int.TryParse(parts[0], out var iterations)) return false;

            var salt = Convert.FromBase64String(parts[1]);
            var expectedHash = Convert.FromBase64String(parts[2]);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            var actualHash = pbkdf2.GetBytes(expectedHash.Length);

            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
    }
}
