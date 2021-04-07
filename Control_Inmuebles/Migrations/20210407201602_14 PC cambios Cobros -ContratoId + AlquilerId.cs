using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class _14PCcambiosCobrosContratoIdAlquilerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContratoDepartamentoId",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "InquilinoId",
                table: "CobroCuotaDepartamento");

            migrationBuilder.AddColumn<int>(
                name: "AlquilerId",
                table: "CobroCuotaDepartamento",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlquilerId",
                table: "CobroCuotaDepartamento");

            migrationBuilder.AddColumn<int>(
                name: "ContratoDepartamentoId",
                table: "CobroCuotaDepartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "CobroCuotaDepartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InquilinoId",
                table: "CobroCuotaDepartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
