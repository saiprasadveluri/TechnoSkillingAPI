using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoSkillingAPI.Data
{
    public class RoleMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid RoleId { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Status { get; set; }
        //Navigation Props
        public IList<UserInfo> UsersInRole { get; set; }
    }
}
