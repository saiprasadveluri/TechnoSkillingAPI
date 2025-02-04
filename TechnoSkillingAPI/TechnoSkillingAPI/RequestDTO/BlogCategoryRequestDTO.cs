using System.ComponentModel.DataAnnotations;

namespace TechnoSkillingAPI.RequestDTO
{
    public class BlogCategoryRequestDTO
    {
        public Guid? BlogCatgId { get; set; }
        [Required]
        public string BlogCatgName { get; set; }
        public IFormFile? BlogCatgIconPicFile { get; set; }
        public string BlogCatgDescription { get; set; }
        public int OrdinalNumber { get; set; } = 1;
    }
}
