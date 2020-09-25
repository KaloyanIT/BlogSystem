using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddFilesLinksAndLibraryModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fm_libraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    StorageType = table.Column<int>(nullable: false),
                    UrlPrefix = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_libraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_links",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    LinkType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    LinkId = table.Column<Guid>(nullable: false),
                    LibraryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fm_files_fm_libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "fm_libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fm_files_fm_links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "fm_links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fm_files_LibraryId",
                table: "fm_files",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_fm_files_LinkId",
                table: "fm_files",
                column: "LinkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fm_files");

            migrationBuilder.DropTable(
                name: "fm_libraries");

            migrationBuilder.DropTable(
                name: "fm_links");
        }
    }
}
