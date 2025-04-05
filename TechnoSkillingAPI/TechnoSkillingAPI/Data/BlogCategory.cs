using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechnoSkillingAPI.Data
{
    //Documentation
    public class BlogCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid BlogCatgId { get; set; }
        [Required]
        [StringLength(50)]
        public string BlogCatgName { get; set; }
        public string? BlogCatgIconPic { get; set; }
        [StringLength(300)]
        public string BlogCatgDescription { get; set; }
        [Required]
        public int OrdinalNumber { get; set; }
        //Nav Props
        public IList<BlogPost> ChildPosts { get; set; }
    }
}
