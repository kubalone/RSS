using Microsoft.EntityFrameworkCore.Migrations;

namespace RSS.DAL.Migrations
{
    public partial class m01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSSFeeds_URLS_URLID",
                table: "RSSFeeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_URLS",
                table: "URLS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSSFeeds",
                table: "RSSFeeds");

            migrationBuilder.RenameTable(
                name: "URLS",
                newName: "URL");

            migrationBuilder.RenameTable(
                name: "RSSFeeds",
                newName: "RssFeed");

            migrationBuilder.RenameIndex(
                name: "IX_RSSFeeds_URLID",
                table: "RssFeed",
                newName: "IX_RssFeed_URLID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_URL",
                table: "URL",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RssFeed",
                table: "RssFeed",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RssFeed_URL_URLID",
                table: "RssFeed",
                column: "URLID",
                principalTable: "URL",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RssFeed_URL_URLID",
                table: "RssFeed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_URL",
                table: "URL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RssFeed",
                table: "RssFeed");

            migrationBuilder.RenameTable(
                name: "URL",
                newName: "URLS");

            migrationBuilder.RenameTable(
                name: "RssFeed",
                newName: "RSSFeeds");

            migrationBuilder.RenameIndex(
                name: "IX_RssFeed_URLID",
                table: "RSSFeeds",
                newName: "IX_RSSFeeds_URLID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_URLS",
                table: "URLS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSSFeeds",
                table: "RSSFeeds",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RSSFeeds_URLS_URLID",
                table: "RSSFeeds",
                column: "URLID",
                principalTable: "URLS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
