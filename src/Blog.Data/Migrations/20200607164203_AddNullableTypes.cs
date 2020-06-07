using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddNullableTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mailLists",
                keyColumn: "Id",
                keyValue: new Guid("09fe78f9-3a31-4912-bc0f-2c0ad1f721d4"));

            migrationBuilder.DeleteData(
                table: "mailLists",
                keyColumn: "Id",
                keyValue: new Guid("7177ebba-6a39-4c6a-bbe2-6c3fe79f4c5a"));

            migrationBuilder.InsertData(
                table: "mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("29b23859-aa8b-448a-ab03-aa93c7e1ca59"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null!, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("c4745eed-e181-4a33-a019-11563d7819c2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null!, "Test2", "Test1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mailLists",
                keyColumn: "Id",
                keyValue: new Guid("29b23859-aa8b-448a-ab03-aa93c7e1ca59"));

            migrationBuilder.DeleteData(
                table: "mailLists",
                keyColumn: "Id",
                keyValue: new Guid("c4745eed-e181-4a33-a019-11563d7819c2"));

            migrationBuilder.InsertData(
                table: "mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("09fe78f9-3a31-4912-bc0f-2c0ad1f721d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null!, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("7177ebba-6a39-4c6a-bbe2-6c3fe79f4c5a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null!, "Test2", "Test1" });
        }
    }
}
