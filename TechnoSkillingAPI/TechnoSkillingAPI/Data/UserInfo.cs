using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoSkillingAPI.Data
{
    public class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]        
        public string Email { get; set; }
        [Required]       
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }
        [Required]        
        public Guid RoleId { get; set; }
        //Navigation Props
        public RoleMaster? ParentRole { get; set; }
        public IList<BlogPost> UserPosts { get; set; }
    }
}
