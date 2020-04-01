using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostKeywords_Blogs_BlogPostId",
                table: "BlogPostKeywords");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostKeywords_Keywords_KeywordId",
                table: "BlogPostKeywords");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTags_Blogs_BlogPostId",
                table: "BlogPostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTags_Tags_TagId",
                table: "BlogPostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_UserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostTags",
                table: "BlogPostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostKeywords",
                table: "BlogPostKeywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "BlogPostTags",
                newName: "blogPostTags");

            migrationBuilder.RenameTable(
                name: "BlogPostKeywords",
                newName: "blogPostKeywords");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "blogPosts");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostTags_TagId",
                table: "blogPostTags",
                newName: "IX_blogPostTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostKeywords_KeywordId",
                table: "blogPostKeywords",
                newName: "IX_blogPostKeywords_KeywordId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_UserId",
                table: "blogPosts",
                newName: "IX_blogPosts_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Keywords",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AttachedItemType",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "blogPosts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "blogPosts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "blogPosts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "blogPosts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPostTags",
                table: "blogPostTags",
                columns: new[] { "BlogPostId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPostKeywords",
                table: "blogPostKeywords",
                columns: new[] { "BlogPostId", "KeywordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPosts",
                table: "blogPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostKeywords_blogPosts_BlogPostId",
                table: "blogPostKeywords",
                column: "BlogPostId",
                principalTable: "blogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostKeywords_Keywords_KeywordId",
                table: "blogPostKeywords",
                column: "KeywordId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogPosts_AspNetUsers_UserId",
                table: "blogPosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostTags_blogPosts_BlogPostId",
                table: "blogPostTags",
                column: "BlogPostId",
                principalTable: "blogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostTags_Tags_TagId",
                table: "blogPostTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogPostKeywords_blogPosts_BlogPostId",
                table: "blogPostKeywords");

            migrationBuilder.DropForeignKey(
                name: "FK_blogPostKeywords_Keywords_KeywordId",
                table: "blogPostKeywords");

            migrationBuilder.DropForeignKey(
                name: "FK_blogPosts_AspNetUsers_UserId",
                table: "blogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_blogPostTags_blogPosts_BlogPostId",
                table: "blogPostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_blogPostTags_Tags_TagId",
                table: "blogPostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPostTags",
                table: "blogPostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPostKeywords",
                table: "blogPostKeywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPosts",
                table: "blogPosts");

            migrationBuilder.RenameTable(
                name: "blogPostTags",
                newName: "BlogPostTags");

            migrationBuilder.RenameTable(
                name: "blogPostKeywords",
                newName: "BlogPostKeywords");

            migrationBuilder.RenameTable(
                name: "blogPosts",
                newName: "Blogs");

            migrationBuilder.RenameIndex(
                name: "IX_blogPostTags_TagId",
                table: "BlogPostTags",
                newName: "IX_BlogPostTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_blogPostKeywords_KeywordId",
                table: "BlogPostKeywords",
                newName: "IX_BlogPostKeywords_KeywordId");

            migrationBuilder.RenameIndex(
                name: "IX_blogPosts_UserId",
                table: "Blogs",
                newName: "IX_Blogs_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Keywords",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AttachedItemType",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Blogs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "Blogs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Blogs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostTags",
                table: "BlogPostTags",
                columns: new[] { "BlogPostId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostKeywords",
                table: "BlogPostKeywords",
                columns: new[] { "BlogPostId", "KeywordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostKeywords_Blogs_BlogPostId",
                table: "BlogPostKeywords",
                column: "BlogPostId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostKeywords_Keywords_KeywordId",
                table: "BlogPostKeywords",
                column: "KeywordId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTags_Blogs_BlogPostId",
                table: "BlogPostTags",
                column: "BlogPostId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTags_Tags_TagId",
                table: "BlogPostTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
