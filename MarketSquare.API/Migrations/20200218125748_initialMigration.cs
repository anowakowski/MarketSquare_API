using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketSquare.API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    CreationDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notices_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscribedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: true),
                    SubscribedUserId = table.Column<int>(nullable: true),
                    IsBlacklisted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscribedUsers_Users_SubscribedUserId",
                        column: x => x.SubscribedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubscribedUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTagSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: true),
                    TagId = table.Column<int>(nullable: true),
                    IsBlacklisted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTagSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTagSubscription_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTagSubscription_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoticeTags",
                columns: table => new
                {
                    NoticeId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticeTags", x => new { x.NoticeId, x.TagId });
                    table.ForeignKey(
                        name: "FK_NoticeTags_Notices_NoticeId",
                        column: x => x.NoticeId,
                        principalTable: "Notices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticeTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoticeId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false),
                    IsSent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotices_Notices_NoticeId",
                        column: x => x.NoticeId,
                        principalTable: "Notices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notices_CreatorId",
                table: "Notices",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NoticeTags_TagId",
                table: "NoticeTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribedUsers_SubscribedUserId",
                table: "SubscribedUsers",
                column: "SubscribedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribedUsers_UserId",
                table: "SubscribedUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotices_NoticeId",
                table: "UserNotices",
                column: "NoticeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotices_UserId",
                table: "UserNotices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTagSubscription_TagId",
                table: "UserTagSubscription",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTagSubscription_UserId",
                table: "UserTagSubscription",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoticeTags");

            migrationBuilder.DropTable(
                name: "SubscribedUsers");

            migrationBuilder.DropTable(
                name: "UserNotices");

            migrationBuilder.DropTable(
                name: "UserTagSubscription");

            migrationBuilder.DropTable(
                name: "Notices");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
