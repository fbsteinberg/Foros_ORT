using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foros_ORT.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creado",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UrlImagen",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "estaActivo",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UrlImagen",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "estaActivo",
                table: "AspNetUsers");
        }
    }
}
