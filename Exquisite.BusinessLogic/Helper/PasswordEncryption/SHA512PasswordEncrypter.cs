using System.Security.Cryptography;
using System.Text;

namespace Exquisite.BusinessLogic.Helper.StringEncryption
{
    internal class SHA512PasswordEncrypter : IPasswordEncrypter
    {
        public string Encrypt(string password, string salt)
        {
            var sha512 = SHA512.Create();
            var bytes = Encoding.UTF8.GetBytes(password + salt);
            var hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            var result = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
