using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddCreatedByAndModifiedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("3cd66d00-f72d-46f3-a0ce-a6e505be7655"));

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("bd24d61e-e8fa-41d1-b0cf-6f98dbd12106"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_tags",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_tags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_subscribers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_subscribers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_settings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_roles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_openGraphs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_openGraphs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_mailListsSubscribers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_mailListsSubscribers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_mailLists",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_mailLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_keywords",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_keywords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_comments",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_blogPostTags",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_blogPostTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_blogPosts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_blogPosts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "fm_blogPostKeywords",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "fm_blogPostKeywords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_tags");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_tags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_subscribers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_subscribers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_settings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_settings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_roles");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_roles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_openGraphs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_openGraphs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_mailListsSubscribers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_mailListsSubscribers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_mailLists");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_mailLists");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_keywords");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_keywords");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_comments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_comments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_blogPostTags");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_blogPostTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_blogPosts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_blogPosts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "fm_blogPostKeywords");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "fm_blogPostKeywords");

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("bd24d61e-e8fa-41d1-b0cf-6f98dbd12106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("3cd66d00-f72d-46f3-a0ce-a6e505be7655"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", "Test1" });
        }
    }
}
