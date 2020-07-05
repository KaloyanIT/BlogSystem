using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddCommentItemType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("59fc9263-ace9-43a2-a347-3c5823471712"));

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("6a229001-7b31-4202-8cd7-95a2eca00fe8"));

            migrationBuilder.DropColumn(
                name: "AttachedItemType",
                table: "fm_comments");

            migrationBuilder.AddColumn<string>(
                name: "CommentItemType",
                table: "fm_comments",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("3ec528a2-6325-4c5e-bb41-6a85d50eaeda"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("7b666388-6bee-4605-b461-72f15c403840"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", "Test1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("3ec528a2-6325-4c5e-bb41-6a85d50eaeda"));

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("7b666388-6bee-4605-b461-72f15c403840"));

            migrationBuilder.DropColumn(
                name: "CommentItemType",
                table: "fm_comments");

            migrationBuilder.AddColumn<string>(
                name: "AttachedItemType",
                table: "fm_comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("59fc9263-ace9-43a2-a347-3c5823471712"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("6a229001-7b31-4202-8cd7-95a2eca00fe8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", "Test1" });
        }
    }
}
