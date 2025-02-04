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
    }
}
