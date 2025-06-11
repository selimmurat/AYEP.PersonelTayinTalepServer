using Application.Interfaces;
using System.Text;
using System.Security.Cryptography;

namespace Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password, out string salt)
        {
            salt = Guid.NewGuid().ToString("N");
            var combined = Encoding.UTF8.GetBytes(password + salt);
            var hash = SHA256.HashData(combined);
            return Convert.ToBase64String(hash);
        }

        public bool VerifyPassword(string password, string hash, string salt)
        {
            var combined = Encoding.UTF8.GetBytes(password + salt);
            var computedHash = SHA256.HashData(combined);
            return Convert.ToBase64String(computedHash) == hash;
        }
    }
}
