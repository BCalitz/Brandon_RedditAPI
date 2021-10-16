using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Brandon_RedditAPI.Migrations
{
    public partial class VotinSys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Downvotes",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Upvotes",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Downvotes",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "Upvotes",
                table: "comments");

            migrationBuilder.AddColumn<Guid>(
                name: "APIKey",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APIKey",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "Downvotes",
                table: "posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Upvotes",
                table: "posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Downvotes",
                table: "comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Upvotes",
                table: "comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
