using Microsoft.EntityFrameworkCore;

namespace TechnoSkillingAPI.Data
{
    public static class Relations
    {
        public static void Add_User_RoleRelation(this ModelBuilder model)
        {
            model.Entity<RoleMaster>()
                .HasMany(r => r.UsersInRole)
                .WithOne(u => u.ParentRole)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static void Add_BlogCatg_PostRelation(this ModelBuilder model)
        {
            model.Entity<BlogCategory>()
                .HasMany(bc => bc.ChildPosts)
                .WithOne(catg=>catg.ParentCategory)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public static void Add_BlogPost_UserInfoRelation(this ModelBuilder model)
        {
            model.Entity<UserInfo>()
                .HasMany(u => u.UserPosts)
                .WithOne(p => p.PostedUser)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
