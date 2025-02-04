using Microsoft.EntityFrameworkCore;
using TechnoSkillingAPI.Utils;

namespace TechnoSkillingAPI.Data
{
    public static class DataSeed
    {
        const string ADMIN_GUID = "939794A9-F9C3-498B-9937-26DA1470C89C";
        const string GUEST_GUID = "B73D97BC-8FC7-4C33-A8EA-F0756ECA0A2A";

        const string ADMIN_USER_ID = "AB8F8762-2E38-4722-A53B-5B104880377C";
        public static void AddRoleData(this ModelBuilder model)
        {
            model.Entity<RoleMaster>().HasData(new RoleMaster()
            {
                RoleId=new Guid(ADMIN_GUID),
                RoleName="Admin",
                Status=1
            });
            model.Entity<RoleMaster>().HasData(new RoleMaster()
            {
                RoleId = new Guid(GUEST_GUID),
                RoleName = "Guest",
                Status = 1
            });
        }

        public static void AddAdminUserData(this ModelBuilder model,IConfiguration config)
        {
            string AdminPassword = config.GetValue<string>("AppData:AdminPassword");
            model.Entity<UserInfo>().HasData(new UserInfo()
            {
                Id = new Guid(ADMIN_USER_ID),
                DisplayName = "Sai Durga",
                Email = "sai_prasad_veluri@yahoo.com",
                Password = CryptoOps.GetHashEncoded(AdminPassword),
                RoleId= new Guid(ADMIN_GUID)
            });
        }
    }
}
