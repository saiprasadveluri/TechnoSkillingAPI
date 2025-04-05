using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TechnoSkillingAPI.Utils
{
    public static class ConfigValueReader
    {
        public static SymmetricSecurityKey GetKey(IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            return securityKey;
        }

        public static string GetIssuer(IConfiguration config)
        {
            return config["Jwt:Issuer"];
        }
    }
}
