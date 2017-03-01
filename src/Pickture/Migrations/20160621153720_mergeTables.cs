using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pickture.Migrations
{
    public partial class mergeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Contempt",
                table: "Images",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Disgust",
                table: "Images",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Fear",
                table: "Images",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Happiness",
                table: "Images",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Neutral",
                table: "Images",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Sadness",
                table: "Images",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Surprise",
                table: "Images",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contempt",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Disgust",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Fear",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Happiness",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Neutral",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Sadness",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Surprise",
                table: "Images");
        }
    }
}
