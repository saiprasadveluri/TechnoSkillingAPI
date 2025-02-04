using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
namespace TechnoSkillingAPI.Utils
{
    public static class CryptoOps
    {
        public static string GetHashEncoded(string inputString)
        {
            
            using (HashAlgorithm algorithm = SHA256.Create())
            {
                byte[] HasedBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
                return Convert.ToBase64String(HasedBytes);
            }
        }
    }
}
