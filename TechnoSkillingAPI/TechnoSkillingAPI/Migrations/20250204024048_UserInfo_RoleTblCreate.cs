using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechnoSkillingAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserInfo_RoleTblCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleMasters",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMasters", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentRoleRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfos_RoleMasters_ParentRoleRoleId",
                        column: x => x.ParentRoleRoleId,
                        principalTable: "RoleMasters",
                        principalColumn: "RoleId");
                });

            migrationBuilder.InsertData(
                table: "RoleMasters",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { new Guid("939794a9-f9c3-498b-9937-26da1470c89c"), "Admin", 1 },
                    { new Guid("b73d97bc-8fc7-4c33-a8ea-f0756eca0a2a"), "Guest", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "DisplayName", "Email", "ParentRoleRoleId", "Password", "RoleId" },
                values: new object[] { new Guid("ab8f8762-2e38-4722-a53b-5b104880377c"), "Sai Durga", "sai_prasad_veluri@yahoo.com", null, "3B58A+FiOXs1W28ciV3983kNmMELkgxV6RJyuO7K2io=", new Guid("939794a9-f9c3-498b-9937-26da1470c89c") });

            migrationBuilder.CreateIndex(
                name: "IX_RoleMasters_RoleName",
                table: "RoleMasters",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_Email",
                table: "UserInfos",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_ParentRoleRoleId",
                table: "UserInfos",
                column: "ParentRoleRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "RoleMasters");
        }
    }
}
