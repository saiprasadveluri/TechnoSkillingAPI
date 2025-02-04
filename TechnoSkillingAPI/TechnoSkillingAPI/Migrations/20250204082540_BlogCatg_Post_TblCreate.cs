using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnoSkillingAPI.Migrations
{
    /// <inheritdoc />
    public partial class BlogCatg_Post_TblCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    BlogCatgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogCatgName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BlogCatgIconPic = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BlogCatgDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.BlogCatgId);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    BlogPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogCatgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogPostTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BlogPostPostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlogPostPostedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogPostStatus = table.Column<int>(type: "int", nullable: false),
                    BlogPosText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogPostItemPic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentCategoryBlogCatgId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.BlogPostId);
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogCategories_ParentCategoryBlogCatgId",
                        column: x => x.ParentCategoryBlogCatgId,
                        principalTable: "BlogCategories",
                        principalColumn: "BlogCatgId");
                    table.ForeignKey(
                        name: "FK_BlogPosts_UserInfos_PostedUserId",
                        column: x => x.PostedUserId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_BlogCatgName",
                table: "BlogCategories",
                column: "BlogCatgName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_ParentCategoryBlogCatgId",
                table: "BlogPosts",
                column: "ParentCategoryBlogCatgId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_PostedUserId",
                table: "BlogPosts",
                column: "PostedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "BlogCategories");
        }
    }
}
