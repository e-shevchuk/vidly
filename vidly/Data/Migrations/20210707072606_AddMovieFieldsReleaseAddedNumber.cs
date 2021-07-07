using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Data.Migrations
{
    public partial class AddMovieFieldsReleaseAddedNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberInStock",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "NumberInStock",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");
        }
    }
}
