using System.ComponentModel.DataAnnotations;

namespace TechnoSkillingAPI.ResponseDTO
{
    public class BlogCategoryResponseDTO
    {
        public Guid? BlogCatgId { get; set; }       
        public string BlogCatgName { get; set; }
        public string BlogCatgIconPic { get; set; }
        public string BlogCatgDescription { get; set; }
        public int OrdinalNumber { get; set; } = 1;
    }
}
