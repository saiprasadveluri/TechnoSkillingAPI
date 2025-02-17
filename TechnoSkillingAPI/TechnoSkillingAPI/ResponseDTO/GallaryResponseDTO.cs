using System.ComponentModel.DataAnnotations;

namespace TechnoSkillingAPI.ResponseDTO
{
    public class GallaryResponseDTO
    {
        public Guid GalleryId { get; set; }        
        public string Caption { get; set; }       
        public string PhtoData { get; set; }
        public string Note { get; set; }       
        public DateTime UploadedDate { get; set; }
    }
}
