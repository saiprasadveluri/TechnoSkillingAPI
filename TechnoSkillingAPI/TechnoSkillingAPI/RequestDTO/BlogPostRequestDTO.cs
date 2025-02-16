using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TechnoSkillingAPI.RequestDTO
{
    public class BlogPostRequestDTO
    {
        public Guid? BlogPostId { get; set; }
        [Required]
        public Guid BlogCatgId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BlogPostTitle { get; set; }
        [Required]        
        public DateTime BlogPostPostedDate { get; set; }
        [Required]
        public Guid BlogPostPostedBy { get; set; }
        [Required]
        public int BlogPostStatus { get; set; }
        public string BlogPosText { get; set; }
        public IFormFile BlogPostItemPicFile { get; set; }
    }
}
