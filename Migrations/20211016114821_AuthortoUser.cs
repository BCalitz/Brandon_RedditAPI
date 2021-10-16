using Microsoft.EntityFrameworkCore.Migrations;

namespace Brandon_RedditAPI.Migrations
{
    public partial class AuthortoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "votes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "posts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "comments",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "votes",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "posts",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "comments",
                newName: "AuthorId");
        }
    }
}
