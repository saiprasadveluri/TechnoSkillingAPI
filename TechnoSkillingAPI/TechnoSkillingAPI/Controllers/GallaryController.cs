using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TechnoSkillingAPI.Repo;
using TechnoSkillingAPI.RequestDTO;
using TechnoSkillingAPI.ResponseDTO;

namespace TechnoSkillingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class GallaryController : ControllerBase
    {
        IRepoBase<GallaryRequestDTO, GallaryResponseDTO> gallaryRepo;
        public GallaryController(IRepoBase<GallaryRequestDTO, GallaryResponseDTO> repo)
        {
            gallaryRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Res= gallaryRepo.GetAll();
            return Ok(new { Data = Res, Status = 1 });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var Res = gallaryRepo.Get(id);
            if(Res==null)
            {
                return BadRequest(new { Data = "Error", Status = 0 });
            }
            else
                return Ok(new { Data = Res, Status = 1 });
        }

        [HttpPost]
        public async Task<IActionResult> Add(GallaryRequestDTO item)
        {
            bool Res=gallaryRepo.Add(item);
            if(!Res)
            {
                return BadRequest(new { Data = "Error", Status = 0 });
            }
            else
            {
                return Ok(new { Data = "Success", Status = 1 });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool Res = gallaryRepo.Delete(id);
            if(!Res)
            {
                return BadRequest(new { Data = "Error", Status = 0 });
            }
            else
            {
                return Ok(new { Data = "Success", Status = 1 });
            }
        }
    }
}
