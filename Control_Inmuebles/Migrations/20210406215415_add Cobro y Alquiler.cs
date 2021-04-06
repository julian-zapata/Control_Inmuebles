using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class addCobroyAlquiler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edificio",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "Inquilino",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "Piso",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "dpto",
                table: "CobroCuotaDepartamento");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "CobroCuotaDepartamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InquilinoId",
                table: "CobroCuotaDepartamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EdificioId",
                table: "Alquiler",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "InquilinoId",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "EdificioId",
                table: "Alquiler");

            migrationBuilder.AddColumn<int>(
                name: "Edificio",
                table: "CobroCuotaDepartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Inquilino",
                table: "CobroCuotaDepartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Piso",
                table: "CobroCuotaDepartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "dpto",
                table: "CobroCuotaDepartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
