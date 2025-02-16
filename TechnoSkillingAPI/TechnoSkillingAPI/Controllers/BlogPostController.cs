using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnoSkillingAPI.Repo;
using TechnoSkillingAPI.RequestDTO;
using TechnoSkillingAPI.ResponseDTO;

namespace TechnoSkillingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        IRepoBase<BlogPostRequestDTO, BlogPostResponseDTO> blogPostRepo;
        public BlogPostController(IRepoBase<BlogPostRequestDTO, BlogPostResponseDTO> repo)
        {
            blogPostRepo = repo;
        }

        [HttpGet("ByParent/{id}")]
        public async Task<ActionResult> GetAll(Guid id)
        {
            var Res = blogPostRepo.GetByParentId(id);
            return Ok(new { Data = Res, Status = 1 });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var Res = blogPostRepo.Get(id);
            return Ok(new { Data = Res, Status = 1 });
        }
        [HttpPost]
        public async Task<ActionResult> AddBlogPost(BlogPostRequestDTO dto)
        {
            bool Res = blogPostRepo.Add(dto);
            if (Res)
            {
                return Ok(new { Data = Res, Status = 1 });
            }
            else
            {
                return BadRequest(new { Data = Res, Status = 0 });
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var Res = blogPostRepo.Delete(id);
            if(Res)
                return Ok(new { Data = Res, Status = 1 });
            else
                return BadRequest(new { Data = Res, Status = 0});
        }
    }
}
