using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.RequestDTO;
using TechnoSkillingAPI.ResponseDTO;
using TechnoSkillingAPI.Utils;

namespace TechnoSkillingAPI.Repo
{
    public class BlogCategoryRepo: IRepoBase<BlogCategoryRequestDTO,BlogCategoryResponseDTO>
    {
        TechnoSkillingDbContext context;
        public BlogCategoryRepo(TechnoSkillingDbContext ctx)
        {
            context = ctx;            
        }

        public bool Add(BlogCategoryRequestDTO item)
        {
            string FileContent = item.BlogCatgIconPicFile != null ? IFormFileReader.ReadContent(item.BlogCatgIconPicFile) : string.Empty;
            BlogCategory catg = new BlogCategory()
            {
                BlogCatgId=Guid.NewGuid(),
                BlogCatgName=item.BlogCatgName,
                BlogCatgDescription=item.BlogCatgDescription,
                OrdinalNumber=item.OrdinalNumber,
                BlogCatgIconPic= FileContent
            };
            context.BlogCategories.Add(catg);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Guid Id)
        {
            var CurRec = context.BlogCategories.FirstOrDefault(catg=>catg.BlogCatgId==Id);
            if(CurRec!=null)
            {
                context.BlogCategories.Remove(CurRec);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public BlogCategoryResponseDTO Get(Guid Id)
        {
            var CurRec = context.BlogCategories.Where(catg => catg.BlogCatgId == Id).Select(
                rec => new BlogCategoryResponseDTO()
                {
                    BlogCatgId= rec.BlogCatgId,
                    BlogCatgName=rec.BlogCatgName,
                    BlogCatgDescription=rec.BlogCatgDescription,
                    BlogCatgIconPic=rec.BlogCatgIconPic,
                    OrdinalNumber=rec.OrdinalNumber
                }).FirstOrDefault();
            return CurRec;
        }

        public IList<BlogCategoryResponseDTO> GetAll()
        {
            var CurRecList = context.BlogCategories.Select(
                rec => new BlogCategoryResponseDTO()
                {
                    BlogCatgId = rec.BlogCatgId,
                    BlogCatgName = rec.BlogCatgName,
                    BlogCatgDescription = rec.BlogCatgDescription,
                    //BlogCatgIconPic = rec.BlogCatgIconPic,
                    OrdinalNumber = rec.OrdinalNumber
                }).ToList();
            return CurRecList;
        }

        public IList<BlogCategoryResponseDTO> GetByParentId(Guid ParentId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid Id, BlogCategoryRequestDTO item)
        {
            var CurRec = context.BlogCategories.Where(catg => catg.BlogCatgId == Id).FirstOrDefault();
            if(CurRec!=null)
            {
                CurRec.BlogCatgName = item.BlogCatgName;
                CurRec.BlogCatgDescription = item.BlogCatgDescription;
                CurRec.OrdinalNumber = item.OrdinalNumber;
                if(item.BlogCatgIconPicFile!=null)
                {
                    CurRec.BlogCatgIconPic = IFormFileReader.ReadContent(item.BlogCatgIconPicFile);
                }
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
