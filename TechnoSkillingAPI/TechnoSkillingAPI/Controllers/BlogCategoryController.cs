using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.Repo;
using TechnoSkillingAPI.RequestDTO;
using TechnoSkillingAPI.ResponseDTO;

namespace TechnoSkillingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class BlogCategoryController : ControllerBase
    {
        IRepoBase<BlogCategoryRequestDTO,BlogCategoryResponseDTO> blogCategoryRepo;
        public BlogCategoryController(IRepoBase<BlogCategoryRequestDTO, BlogCategoryResponseDTO> repo)
        {
            blogCategoryRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
           var Res=blogCategoryRepo.GetAll();
            return Ok(new { Data = Res, Status = 1 });
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var Res = blogCategoryRepo.Get(Id);
            if(Res!=null)
                return Ok(new { Data = Res, Status = 1 });
            else
                return BadRequest(new{ Data = "Error", Status = 0 });
        }
        [HttpPost]
        public async Task<ActionResult> AddBlogCategory(BlogCategoryRequestDTO dto)
        {
           bool Res= blogCategoryRepo.Add(dto);
            if(Res)
            {
                return Ok(new { Data = Res, Status = 1 });
            }
            else
            {
                return BadRequest(new { Data = Res, Status = 0 });
            }
        }
        [HttpPut]
        public async Task<ActionResult> EditBlogCategory(BlogCategoryRequestDTO dto)
        {
            bool Res = blogCategoryRepo.Update(dto.BlogCatgId.Value, dto);
            if (Res)
            {
                return Ok(new { Data = Res, Status = 1 });
            }
            else
            {
                return BadRequest(new { Data = Res, Status = 0 });
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteBlogCategory(Guid Id)
        {
            bool Res = blogCategoryRepo.Delete(Id);
            if (Res)
            {
                return Ok(new { Data = Res, Status = 1 });
            }
            else
            {
                return BadRequest(new { Data = "Error", Status = 0 });
            }
        }
    }
}
