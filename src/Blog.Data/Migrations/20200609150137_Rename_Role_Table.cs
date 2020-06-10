using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class Rename_Role_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fm_roleClaims_AspNetRoles_RoleId",
                table: "fm_roleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_fm_userRoles_AspNetRoles_RoleId",
                table: "fm_userRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("be3c1b9a-92a2-4f9e-8b0e-522614e25c19"));

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("d71f1922-5aac-41d9-ba6a-555040890655"));

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "fm_roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fm_roles",
                table: "fm_roles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                values: new object[] { new Guid("a0be145c-8f9b-4eab-82f2-269a3ad9ac49"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", "Test" });
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                values: new object[] { new Guid("e33a0889-0772-456c-ae7c-0354fb2c93fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", "Test1" });
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            migrationBuilder.AddForeignKey(
                name: "FK_fm_roleClaims_fm_roles_RoleId",
                table: "fm_roleClaims",
                column: "RoleId",
                principalTable: "fm_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fm_userRoles_fm_roles_RoleId",
                table: "fm_userRoles",
                column: "RoleId",
                principalTable: "fm_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fm_roleClaims_fm_roles_RoleId",
                table: "fm_roleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_fm_userRoles_fm_roles_RoleId",
                table: "fm_userRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fm_roles",
                table: "fm_roles");

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("a0be145c-8f9b-4eab-82f2-269a3ad9ac49"));

            migrationBuilder.DeleteData(
                table: "fm_mailLists",
                keyColumn: "Id",
                keyValue: new Guid("e33a0889-0772-456c-ae7c-0354fb2c93fe"));

            migrationBuilder.RenameTable(
                name: "fm_roles",
                newName: "AspNetRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                values: new object[] { new Guid("be3c1b9a-92a2-4f9e-8b0e-522614e25c19"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", "Test" });
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                values: new object[] { new Guid("d71f1922-5aac-41d9-ba6a-555040890655"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", "Test1" });
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            migrationBuilder.AddForeignKey(
                name: "FK_fm_roleClaims_AspNetRoles_RoleId",
                table: "fm_roleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fm_userRoles_AspNetRoles_RoleId",
                table: "fm_userRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
