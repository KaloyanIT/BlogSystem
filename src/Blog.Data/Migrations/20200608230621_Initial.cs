using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_keywords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_keywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_mailLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_mailLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_subscribers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fm_users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fm_mailListsSubscribers",
                columns: table => new
                {
                    SubscriberId = table.Column<Guid>(nullable: false),
                    MailListId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_mailListsSubscribers", x => new { x.MailListId, x.SubscriberId });
                    table.ForeignKey(
                        name: "FK_fm_mailListsSubscribers_fm_mailLists_MailListId",
                        column: x => x.MailListId,
                        principalTable: "fm_mailLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fm_mailListsSubscribers_fm_subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "fm_subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_fm_users_UserId",
                        column: x => x.UserId,
                        principalTable: "fm_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_fm_users_UserId",
                        column: x => x.UserId,
                        principalTable: "fm_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_fm_users_UserId",
                        column: x => x.UserId,
                        principalTable: "fm_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_fm_users_UserId",
                        column: x => x.UserId,
                        principalTable: "fm_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fm_blogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    ShowOnHomePage = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_blogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fm_blogPosts_fm_users_UserId",
                        column: x => x.UserId,
                        principalTable: "fm_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fm_comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    AttachedItemId = table.Column<Guid>(nullable: false),
                    AttachedItemType = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fm_comments_fm_users_UserId",
                        column: x => x.UserId,
                        principalTable: "fm_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fm_blogPostKeywords",
                columns: table => new
                {
                    BlogPostId = table.Column<Guid>(nullable: false),
                    KeywordId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_blogPostKeywords", x => new { x.BlogPostId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_fm_blogPostKeywords_fm_blogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "fm_blogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fm_blogPostKeywords_fm_keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "fm_keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fm_blogPostTags",
                columns: table => new
                {
                    BlogPostId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fm_blogPostTags", x => new { x.BlogPostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_fm_blogPostTags_fm_blogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "fm_blogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fm_blogPostTags_fm_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "fm_tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("67d42294-b944-4021-b398-913eb1d29f57"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "fm_mailLists",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { new Guid("b37c6cce-91dd-4c13-a2d2-1e57f7e660d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", "Test1" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_fm_blogPostKeywords_KeywordId",
                table: "fm_blogPostKeywords",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_fm_blogPosts_UserId",
                table: "fm_blogPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_fm_blogPostTags_TagId",
                table: "fm_blogPostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_fm_comments_UserId",
                table: "fm_comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_fm_mailListsSubscribers_SubscriberId",
                table: "fm_mailListsSubscribers",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "fm_users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "fm_users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "fm_blogPostKeywords");

            migrationBuilder.DropTable(
                name: "fm_blogPostTags");

            migrationBuilder.DropTable(
                name: "fm_comments");

            migrationBuilder.DropTable(
                name: "fm_mailListsSubscribers");

            migrationBuilder.DropTable(
                name: "fm_settings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "fm_keywords");

            migrationBuilder.DropTable(
                name: "fm_blogPosts");

            migrationBuilder.DropTable(
                name: "fm_tags");

            migrationBuilder.DropTable(
                name: "fm_mailLists");

            migrationBuilder.DropTable(
                name: "fm_subscribers");

            migrationBuilder.DropTable(
                name: "fm_users");
        }
    }
}
