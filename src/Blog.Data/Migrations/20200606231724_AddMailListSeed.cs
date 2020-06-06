using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddMailListSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("dfb54173-ba0b-4037-a6ce-0cb9273ff307"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test", "Test" });

            migrationBuilder.InsertData(
                table: "mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("34f7fdeb-63ee-4170-ae5a-07d0452244aa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test2", "Test1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mailLists",
                keyColumn: "Id",
                keyValue: new Guid("34f7fdeb-63ee-4170-ae5a-07d0452244aa"));

            migrationBuilder.DeleteData(
                table: "mailLists",
                keyColumn: "Id",
                keyValue: new Guid("dfb54173-ba0b-4037-a6ce-0cb9273ff307"));
        }
    }
}
