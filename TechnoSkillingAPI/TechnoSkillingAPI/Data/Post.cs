using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TechnoSkillingAPI.Data
{
    public class BlogPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid BlogPostId { get; set; }
        [Required]
        public Guid BlogCatgId { get; set; }
        [Required]
        [StringLength(50)]
        public string BlogPostTitle { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BlogPostPostedDate { get; set; }
        [Required]
        public Guid BlogPostPostedBy { get; set; }
        [Required]
        [DefaultValue(1)]
        public int BlogPostStatus { get; set; }
        public string BlogPosText { get; set; }
        public string BlogPostItemPic { get; set; }
        //Nav Props
        public UserInfo PostedUser { get; set; }
        public BlogCategory ParentCategory { get; set; }
    }
}
