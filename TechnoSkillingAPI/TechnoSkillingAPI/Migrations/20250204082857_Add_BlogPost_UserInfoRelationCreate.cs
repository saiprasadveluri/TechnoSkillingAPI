using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnoSkillingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_BlogPost_UserInfoRelationCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_UserInfos_PostedUserId",
                table: "BlogPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_UserInfos_PostedUserId",
                table: "BlogPosts",
                column: "PostedUserId",
                principalTable: "UserInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_UserInfos_PostedUserId",
                table: "BlogPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_UserInfos_PostedUserId",
                table: "BlogPosts",
                column: "PostedUserId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
