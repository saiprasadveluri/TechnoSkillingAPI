using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace TechnoSkillingAPI.Data
{
    public class TechnoSkillingDbContext:DbContext
    {
        public IConfiguration config { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public TechnoSkillingDbContext(IConfiguration cfg)
        {
            config = cfg;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            string ConfigConString = config.GetConnectionString("DbConString");
            optionsBuilder.UseSqlServer(ConfigConString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Setup_Roles();
            modelBuilder.Setup_UserInfo();
            modelBuilder.Add_User_RoleRelation();
            modelBuilder.AddRoleData();
            modelBuilder.AddAdminUserData(config);
            modelBuilder.Setup_BlogCategory();
            modelBuilder.Add_BlogCatg_PostRelation();
            modelBuilder.Add_BlogPost_UserInfoRelation();
        }
    }
}
