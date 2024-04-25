using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Linq;

    public class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

        public static string HashPassword(string password)
        {
            var salt = new byte[SaltSize];
            RandomNumberGenerator.Fill(salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithm))
            {
                var hash = pbkdf2.GetBytes(HashSize);
                var result = $"{Convert.ToBase64String(salt)}:{Iterations}:{Convert.ToBase64String(hash)}";
                return result;
            }
        }

        public static bool VerifyPassword(string storedHash, string enteredPassword)
        {
            var parts = storedHash.Split(':');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Formato de hash inválido.");
            }

            var salt = Convert.FromBase64String(parts[0]);
            var iterations = int.Parse(parts[1]);
            var storedHashBytes = Convert.FromBase64String(parts[2]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, iterations, HashAlgorithm))
            {
                var enteredHashBytes = pbkdf2.GetBytes(HashSize);

                return Enumerable.SequenceEqual(enteredHashBytes, storedHashBytes);
            }
        }
    }

}
