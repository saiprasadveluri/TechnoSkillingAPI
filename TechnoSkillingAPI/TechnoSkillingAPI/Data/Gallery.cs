using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoSkillingAPI.Data
{
    public class Gallery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid GalleryId { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public string PhtoData { get; set; }
        public string Note { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime UploadedDate { get; set; }
        
    }
}
