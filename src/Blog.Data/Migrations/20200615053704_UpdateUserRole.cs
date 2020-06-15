using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class UpdateUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("a0be145c-8f9b-4eab-82f2-269a3ad9ac49"));

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("e33a0889-0772-456c-ae7c-0354fb2c93fe"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "fm_users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "fm_users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "fm_roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "fm_roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "fm_roles",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "DateCreated",
                table: "fm_roles");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "fm_roles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "fm_roles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "fm_users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "fm_users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("a0be145c-8f9b-4eab-82f2-269a3ad9ac49"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("e33a0889-0772-456c-ae7c-0354fb2c93fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", "Test1" });
        }
    }
}
