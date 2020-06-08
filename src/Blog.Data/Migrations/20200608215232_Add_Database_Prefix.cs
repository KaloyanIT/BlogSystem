using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class Add_Database_Prefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_MailListSubscribers_mailLists_MailListId",
                table: "MailListSubscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_MailListSubscribers_subscirbers_SubscriberId",
                table: "MailListSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subscirbers",
                table: "subscirbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_settings",
                table: "settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MailListSubscribers",
                table: "MailListSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mailLists",
                table: "mailLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keywords",
                table: "Keywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPostTags",
                table: "blogPostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPosts",
                table: "blogPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPostKeywords",
                table: "blogPostKeywords");

            migrationBuilder.DeleteData(
                table: "mailLists",
                keyColumn: "Id",
                keyValue: new Guid("29b23859-aa8b-448a-ab03-aa93c7e1ca59"));

            migrationBuilder.DeleteData(
                table: "mailLists",
                keyColumn: "Id",
                keyValue: new Guid("c4745eed-e181-4a33-a019-11563d7819c2"));

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "fm_tags");

            migrationBuilder.RenameTable(
                name: "subscirbers",
                newName: "fm_subscribers");

            migrationBuilder.RenameTable(
                name: "settings",
                newName: "fm_settings");

            migrationBuilder.RenameTable(
                name: "MailListSubscribers",
                newName: "fm_mailListsSubscribers");

            migrationBuilder.RenameTable(
                name: "mailLists",
                newName: "fm_mailLists");

            migrationBuilder.RenameTable(
                name: "Keywords",
                newName: "fm_keywords");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "fm_comments");

            migrationBuilder.RenameTable(
                name: "blogPostTags",
                newName: "fm_blogPostTags");

            migrationBuilder.RenameTable(
                name: "blogPosts",
                newName: "fm_blogPosts");

            migrationBuilder.RenameTable(
                name: "blogPostKeywords",
                newName: "fm_blogPostKeywords");

            migrationBuilder.RenameIndex(
                name: "IX_MailListSubscribers_SubscriberId",
                table: "fm_mailListsSubscribers",
                newName: "IX_fm_mailListsSubscribers_SubscriberId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "fm_comments",
                newName: "IX_fm_comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_blogPostTags_TagId",
                table: "fm_blogPostTags",
                newName: "IX_fm_blogPostTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_blogPosts_UserId",
                table: "fm_blogPosts",
                newName: "IX_fm_blogPosts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_blogPostKeywords_KeywordId",
                table: "fm_blogPostKeywords",
                newName: "IX_fm_blogPostKeywords_KeywordId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "fm_comments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_tags",
                table: "fm_tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_subscribers",
                table: "fm_subscribers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_settings",
                table: "fm_settings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_mailListsSubscribers",
                table: "fm_mailListsSubscribers",
                columns: new[] { "MailListId", "SubscriberId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_mailLists",
                table: "fm_mailLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_keywords",
                table: "fm_keywords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_comments",
                table: "fm_comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_blogPostTags",
                table: "fm_blogPostTags",
                columns: new[] { "BlogPostId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_blogPosts",
                table: "fm_blogPosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_blogPostKeywords",
                table: "fm_blogPostKeywords",
                columns: new[] { "BlogPostId", "KeywordId" });

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("979877d5-7b32-416c-b8a3-7dd2cd8dca20"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("16ffb3cb-d188-438d-bea0-73c6f6270c11"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", "Test1" });

            migrationBuilder.AddForeignKey(
                name: "FK_fm_blogPostKeywords_fm_blogPosts_BlogPostId",
                table: "fm_blogPostKeywords",
                column: "BlogPostId",
                principalTable: "fm_blogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fm_blogPostKeywords_fm_keywords_KeywordId",
                table: "fm_blogPostKeywords",
                column: "KeywordId",
                principalTable: "fm_keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fm_blogPosts_AspNetUsers_UserId",
                table: "fm_blogPosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fm_blogPostTags_fm_blogPosts_BlogPostId",
                table: "fm_blogPostTags",
                column: "BlogPostId",
                principalTable: "fm_blogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fm_blogPostTags_fm_tags_TagId",
                table: "fm_blogPostTags",
                column: "TagId",
                principalTable: "fm_tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fm_comments_AspNetUsers_UserId",
                table: "fm_comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_fm_mailListsSubscribers_fm_mailLists_MailListId",
                table: "fm_mailListsSubscribers",
                column: "MailListId",
                principalTable: "fm_mailLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fm_mailListsSubscribers_fm_subscribers_SubscriberId",
                table: "fm_mailListsSubscribers",
                column: "SubscriberId",
                principalTable: "fm_subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fm_blogPostKeywords_fm_blogPosts_BlogPostId",
                table: "fm_blogPostKeywords");

            migrationBuilder.DropForeignKey(
                name: "FK_fm_blogPostKeywords_fm_keywords_KeywordId",
                table: "fm_blogPostKeywords");

            migrationBuilder.DropForeignKey(
                name: "FK_fm_blogPosts_AspNetUsers_UserId",
                table: "fm_blogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_fm_blogPostTags_fm_blogPosts_BlogPostId",
                table: "fm_blogPostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_fm_blogPostTags_fm_tags_TagId",
                table: "fm_blogPostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_fm_comments_AspNetUsers_UserId",
                table: "fm_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_fm_mailListsSubscribers_fm_mailLists_MailListId",
                table: "fm_mailListsSubscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_fm_mailListsSubscribers_fm_subscribers_SubscriberId",
                table: "fm_mailListsSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_tags",
                table: "fm_tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_subscribers",
                table: "fm_subscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_settings",
                table: "fm_settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_mailListsSubscribers",
                table: "fm_mailListsSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_mailLists",
                table: "fm_mailLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_keywords",
                table: "fm_keywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_comments",
                table: "fm_comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_blogPostTags",
                table: "fm_blogPostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_blogPosts",
                table: "fm_blogPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_blogPostKeywords",
                table: "fm_blogPostKeywords");

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("16ffb3cb-d188-438d-bea0-73c6f6270c11"));

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("979877d5-7b32-416c-b8a3-7dd2cd8dca20"));

            migrationBuilder.RenameTable(
                name: "fm_tags",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "fm_subscribers",
                newName: "subscirbers");

            migrationBuilder.RenameTable(
                name: "fm_settings",
                newName: "settings");

            migrationBuilder.RenameTable(
                name: "fm_mailListsSubscribers",
                newName: "MailListSubscribers");

            migrationBuilder.RenameTable(
                name: "fm_mailLists",
                newName: "mailLists");

            migrationBuilder.RenameTable(
                name: "fm_keywords",
                newName: "Keywords");

            migrationBuilder.RenameTable(
                name: "fm_comments",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "fm_blogPostTags",
                newName: "blogPostTags");

            migrationBuilder.RenameTable(
                name: "fm_blogPosts",
                newName: "blogPosts");

            migrationBuilder.RenameTable(
                name: "fm_blogPostKeywords",
                newName: "blogPostKeywords");

            migrationBuilder.RenameIndex(
                name: "IX_fm_mailListsSubscribers_SubscriberId",
                table: "MailListSubscribers",
                newName: "IX_MailListSubscribers_SubscriberId");

            migrationBuilder.RenameIndex(
                name: "IX_fm_comments_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_fm_blogPostTags_TagId",
                table: "blogPostTags",
                newName: "IX_blogPostTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_fm_blogPosts_UserId",
                table: "blogPosts",
                newName: "IX_blogPosts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_fm_blogPostKeywords_KeywordId",
                table: "blogPostKeywords",
                newName: "IX_blogPostKeywords_KeywordId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subscirbers",
                table: "subscirbers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_settings",
                table: "settings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MailListSubscribers",
                table: "MailListSubscribers",
                columns: new[] { "MailListId", "SubscriberId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_mailLists",
                table: "mailLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keywords",
                table: "Keywords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPostTags",
                table: "blogPostTags",
                columns: new[] { "BlogPostId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPosts",
                table: "blogPosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPostKeywords",
                table: "blogPostKeywords",
                columns: new[] { "BlogPostId", "KeywordId" });

            migrationBuilder.InsertData(
                table: "mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("29b23859-aa8b-448a-ab03-aa93c7e1ca59"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("c4745eed-e181-4a33-a019-11563d7819c2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", "Test1" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_MailListSubscribers_mailLists_MailListId",
                table: "MailListSubscribers",
                column: "MailListId",
                principalTable: "mailLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MailListSubscribers_subscirbers_SubscriberId",
                table: "MailListSubscribers",
                column: "SubscriberId",
                principalTable: "subscirbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
