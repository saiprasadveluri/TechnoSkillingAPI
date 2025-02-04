using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.Repo;
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
        LoginRepo loginRepo;
        public LoginController(TechnoSkillingDbContext ctx,IConfiguration cfg)
        {
            loginRepo = new LoginRepo(ctx, cfg);
        }
        [HttpPost]
        public async Task<ActionResult> LoginUser(LoginRequestDTO req)
        {
            string Email = req.Email;
            string Password = req.Password;
            LoginResponseDTO Res = await loginRepo.LoginUser(Email, Password);
            if (Res!=null)
            {
                return Ok(new { Data = Res, Status = 1 });
            }
            else
            {
                return BadRequest(new { Status = 0, ErrorMessage = "Error In login" });
            }
        }        
    }
}
