using System.ComponentModel.DataAnnotations;

namespace TechnoSkillingAPI.RequestDTO
{
    public class GallaryRequestDTO
    {
        public Guid GalleryId { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public IFormFile PhtoDataFile { get; set; }
        public string Note { get; set; }
        [Required]
       public DateTime UploadedDate { get; set; }
    }
}
