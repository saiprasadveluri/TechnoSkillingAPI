using Microsoft.EntityFrameworkCore;

namespace TechnoSkillingAPI.Data
{
    public static class TableConstraints
    {
        public static void Setup_Roles(this ModelBuilder model)
        {
            model.Entity<RoleMaster>().HasIndex(p => p.RoleName).IsUnique(true);
        }

        public static void Setup_UserInfo(this ModelBuilder model)
        {
            model.Entity<UserInfo>().HasIndex(p => p.Email).IsUnique(true);
        }
        public static void Setup_BlogCategory(this ModelBuilder model)
        {
            model.Entity<BlogCategory>().HasIndex(p => p.BlogCatgName).IsUnique(true);
        }

    }
}
