using System.ComponentModel.DataAnnotations;

namespace TechnoSkillingAPI.ResponseDTO
{
    public class BlogPostResponseDTO
    {
        public Guid BlogPostId { get; set; }
        public string BlogCatgName { get; set; }
        public string BlogPostTitle { get; set; }
        public DateTime BlogPostPostedDate { get; set; }
        public Guid BlogPostPostedBy { get; set; }
        public int BlogPostStatus { get; set; }
        public string BlogPosText { get; set; }
        public string BlogPostItemPic { get; set; }
    }
}
