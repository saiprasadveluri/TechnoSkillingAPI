using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.RequestDTO;
using TechnoSkillingAPI.ResponseDTO;
using TechnoSkillingAPI.Utils;

namespace TechnoSkillingAPI.Repo
{
    public class GallaryRepo : IRepoBase<GallaryRequestDTO, GallaryResponseDTO>
    {

        TechnoSkillingDbContext context;
        public GallaryRepo(TechnoSkillingDbContext ctx)
        {
            context = ctx;
        }

        public bool Add(GallaryRequestDTO item)
        {
            string FileContent = item.PhtoDataFile != null ? IFormFileReader.ReadContent(item.PhtoDataFile) : string.Empty;
            if(String.IsNullOrEmpty(FileContent))
            {
                return false;
            }
            Gallery newRec = new Gallery()
            {
                GalleryId=Guid.NewGuid(),
                Caption=item.Caption,
                Note=item.Note,
                UploadedDate=item.UploadedDate,
                PhtoData= FileContent
            };
            context.Galleries.Add(newRec);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Guid Id)
        {
            var Rec = (from obj in context.Galleries
                       where obj.GalleryId == Id
                       select obj).FirstOrDefault();
            if(Rec==null)
            {
                return false;
            }
            context.Galleries.Remove(Rec);
            context.SaveChanges();
            return true;
        }

        public GallaryResponseDTO Get(Guid id)
        {
            var Rec = (from obj in context.Galleries
                       where obj.GalleryId == id
                       select new GallaryResponseDTO()
                       {
                            GalleryId=obj.GalleryId,
                            Caption=obj.Caption,
                            Note=obj.Note,
                            UploadedDate=obj.UploadedDate,
                            PhtoData=obj.PhtoData
                       }).FirstOrDefault();
            return Rec;
        }

        public IList<GallaryResponseDTO> GetAll()
        {
            var Recs = (from obj in context.Galleries                       
                       select new GallaryResponseDTO()
                       {
                           GalleryId = obj.GalleryId,
                           Caption = obj.Caption,
                           Note = obj.Note,
                           UploadedDate = obj.UploadedDate,                           
                       }).ToList();
            return Recs;
        }

        public IList<GallaryResponseDTO> GetByParentId(Guid ParentId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, GallaryRequestDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
