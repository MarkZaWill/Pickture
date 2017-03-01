using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickture.Migrations
{
    public partial class imagemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialMediaName",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaName",
                table: "Images",
                nullable: true);
        }
    }
}
