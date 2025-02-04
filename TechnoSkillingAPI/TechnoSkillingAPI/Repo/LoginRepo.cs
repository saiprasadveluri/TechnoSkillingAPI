using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.ResponseDTO;
using TechnoSkillingAPI.Utils;

namespace TechnoSkillingAPI.Repo
{
    public class LoginRepo
    {
        TechnoSkillingDbContext context;
        static IConfiguration config;
        public LoginRepo(TechnoSkillingDbContext ctx, IConfiguration cfg)
        {
            context = ctx;
            config=cfg;
        }
        public async Task<LoginResponseDTO> LoginUser(string Email,string Password)
        {
            string HashedPassword= CryptoOps.GetHashEncoded(Password);
            LoginResponseDTO? Res = (from uobj in context.UserInfos
                                     join robj in context.RoleMasters on uobj.RoleId equals robj.RoleId
                                     where uobj.Email == Email && uobj.Password == HashedPassword
                                     select new LoginResponseDTO()
                                     {
                                         DisplayName = uobj.DisplayName,
                                         Jwt = GenerateJWT(robj.RoleName, uobj.Id.ToString())
                                     }).FirstOrDefault();
            return Res;
        }

        private static string GenerateJWT(string Roleval, string UserId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,Roleval),
                new Claim("UserId",UserId)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
