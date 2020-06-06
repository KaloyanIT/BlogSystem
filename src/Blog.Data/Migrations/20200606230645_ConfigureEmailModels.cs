using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class ConfigureEmailModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailListSubscribers_MailLists_MailListId",
                table: "MailListSubscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_MailListSubscribers_Subscribers_SubscriberId",
                table: "MailListSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MailListSubscribers",
                table: "MailListSubscribers");

            migrationBuilder.DropIndex(
                name: "IX_MailListSubscribers_MailListId",
                table: "MailListSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MailLists",
                table: "MailLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "SusbcriberId",
                table: "MailListSubscribers");

            migrationBuilder.RenameTable(
                name: "MailLists",
                newName: "mailLists");

            migrationBuilder.RenameTable(
                name: "Subscribers",
                newName: "subscirbers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MailListSubscribers",
                table: "MailListSubscribers",
                columns: new[] { "MailListId", "SubscriberId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_mailLists",
                table: "mailLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subscirbers",
                table: "subscirbers",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailListSubscribers_mailLists_MailListId",
                table: "MailListSubscribers");

            migrationBuilder.DropForeignKey(
                name: "FK_MailListSubscribers_subscirbers_SubscriberId",
                table: "MailListSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MailListSubscribers",
                table: "MailListSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mailLists",
                table: "mailLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subscirbers",
                table: "subscirbers");

            migrationBuilder.RenameTable(
                name: "mailLists",
                newName: "MailLists");

            migrationBuilder.RenameTable(
                name: "subscirbers",
                newName: "Subscribers");

            migrationBuilder.AddColumn<Guid>(
                name: "SusbcriberId",
                table: "MailListSubscribers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MailListSubscribers",
                table: "MailListSubscribers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MailLists",
                table: "MailLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MailListSubscribers_MailListId",
                table: "MailListSubscribers",
                column: "MailListId");

            migrationBuilder.AddForeignKey(
                name: "FK_MailListSubscribers_MailLists_MailListId",
                table: "MailListSubscribers",
                column: "MailListId",
                principalTable: "MailLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MailListSubscribers_Subscribers_SubscriberId",
                table: "MailListSubscribers",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
