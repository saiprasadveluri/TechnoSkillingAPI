using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.RequestDTO;
using TechnoSkillingAPI.ResponseDTO;
using TechnoSkillingAPI.Utils;

namespace TechnoSkillingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class LoginController : ControllerBase
    {
        TechnoSkillingDbContext context;
        static IConfiguration config;
        public LoginController(TechnoSkillingDbContext ctx,IConfiguration cfg)
        {
            context = ctx;
            config = cfg;
        }
        [HttpPost]
        public IActionResult LoginUser(LoginRequestDTO req)
        {
            string Email = req.Email;
            string Password = req.Password;
            string HasedPassword=CryptoOps.GetHashEncoded(Password);
            LoginResponseDTO? Res = (from uobj in context.UserInfos
                      join robj in context.RoleMasters on uobj.RoleId equals robj.RoleId
                      where uobj.Email == Email && uobj.Password == HasedPassword
                      select new LoginResponseDTO()
                      {
                         DisplayName=uobj.DisplayName,
                         Jwt= GenerateJWT(robj.RoleName, uobj.Id.ToString())
                      }).FirstOrDefault();
            if(Res!=null)
            {
                return Ok(new { Data = Res, Status = 1 });
            }
            else
            {
                return BadRequest(new { Status = 0, ErrorMessage = "Error In login" });
            }

        }

        private static string GenerateJWT(string Roleval,string UserId)
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
