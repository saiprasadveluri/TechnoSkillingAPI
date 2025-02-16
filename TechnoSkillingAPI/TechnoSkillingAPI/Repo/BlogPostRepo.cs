using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.RequestDTO;
using TechnoSkillingAPI.ResponseDTO;
using TechnoSkillingAPI.Utils;

namespace TechnoSkillingAPI.Repo
{
    public class BlogPostRepo : IRepoBase<BlogPostRequestDTO, BlogPostResponseDTO>
    {
        TechnoSkillingDbContext context;
        public BlogPostRepo(TechnoSkillingDbContext ctx)
        {
            context = ctx;
        }
        public bool Add(BlogPostRequestDTO item)
        {
            string FileContent = item.BlogPostItemPicFile != null ? IFormFileReader.ReadContent(item.BlogPostItemPicFile) : string.Empty;
            BlogPost Post = new BlogPost()
            {
                BlogPostId = Guid.NewGuid(),
                BlogPostPostedBy = item.BlogPostPostedBy,
                BlogPostPostedDate = item.BlogPostPostedDate,
                BlogPostItemPic = FileContent,
                BlogPostTitle = item.BlogPostTitle,
                BlogPosText = item.BlogPosText,
                BlogPostStatus = 1,
                BlogCatgId = item.BlogCatgId
            };
            context.BlogPosts.Add(Post);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Guid Id)
        {
            var Res = (from pobj in context.BlogPosts
                       join catObj in context.BlogCategories on pobj.BlogCatgId equals catObj.BlogCatgId
                       where pobj.BlogPostId == Id
                       select pobj
                       ).FirstOrDefault();
            if(Res!=null)
            {
                context.BlogPosts.Remove(Res);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public BlogPostResponseDTO Get(Guid id)
        {
            var Res = (from pobj in context.BlogPosts
                       join catObj in context.BlogCategories on pobj.BlogCatgId equals catObj.BlogCatgId
                       where pobj.BlogPostId == id
                       select new BlogPostResponseDTO()
                       {
                           BlogPostId = pobj.BlogPostId,
                           BlogCatgName = catObj.BlogCatgName,
                           BlogPosText = pobj.BlogPosText,
                           BlogPostPostedBy = pobj.BlogPostPostedBy,
                           BlogPostPostedDate = pobj.BlogPostPostedDate,
                           BlogPostItemPic = pobj.BlogPostItemPic,
                           BlogPostTitle = pobj.BlogPostTitle,
                           BlogPostStatus = pobj.BlogPostStatus
                       }).FirstOrDefault();
            return Res;
        }

        public IList<BlogPostResponseDTO> GetAll()
        {
            var Res = (from pobj in context.BlogPosts
                       join catObj in context.BlogCategories on pobj.BlogCatgId equals catObj.BlogCatgId                       
                       select new BlogPostResponseDTO()
                       {
                           BlogPostId = pobj.BlogPostId,
                           BlogCatgName = catObj.BlogCatgName,
                           BlogPosText = pobj.BlogPosText,
                           BlogPostPostedBy = pobj.BlogPostPostedBy,
                           BlogPostPostedDate = pobj.BlogPostPostedDate,
                           //BlogPostItemPic = pobj.BlogPostItemPic,
                           BlogPostTitle = pobj.BlogPostTitle,
                           BlogPostStatus = pobj.BlogPostStatus
                       }).ToList();
            return Res;
        }

        public IList<BlogPostResponseDTO> GetByParentId(Guid ParentId)
        {
            var Res = (from pobj in context.BlogPosts
             join catObj in context.BlogCategories on pobj.BlogCatgId equals catObj.BlogCatgId
             where catObj.BlogCatgId==ParentId
             select new BlogPostResponseDTO()
             {
                 BlogPostId = pobj.BlogPostId,
                 BlogCatgName = catObj.BlogCatgName,
                 BlogPosText = pobj.BlogPosText,
                 BlogPostPostedBy = pobj.BlogPostPostedBy,
                 BlogPostPostedDate = pobj.BlogPostPostedDate,
                 //BlogPostItemPic = pobj.BlogPostItemPic,
                 BlogPostTitle = pobj.BlogPostTitle,
                 BlogPostStatus = pobj.BlogPostStatus
             }).ToList();
            return Res;
        }

        public bool Update(Guid id, BlogPostRequestDTO item)
        {
            string FileContent = item.BlogPostItemPicFile != null ? IFormFileReader.ReadContent(item.BlogPostItemPicFile) : string.Empty;
            var Res = (from pobj in context.BlogPosts
                       join catObj in context.BlogCategories on pobj.BlogCatgId equals catObj.BlogCatgId
                       where pobj.BlogPostId == id
                       select pobj
                       ).FirstOrDefault();
            if(Res!=null)
            {
                Res.BlogPostTitle = item.BlogPostTitle;
                Res.BlogPosText = item.BlogPosText;
                if (!String.IsNullOrEmpty(FileContent))
                    Res.BlogPostItemPic = FileContent;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
