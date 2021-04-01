using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class changesinContratoclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinoInmueble",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "InmuebleId",
                table: "Contrato");

            migrationBuilder.AddColumn<string>(
                name: "Inmueble",
                table: "Contrato",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inmueble",
                table: "Contrato");

            migrationBuilder.AddColumn<string>(
                name: "DestinoInmueble",
                table: "Contrato",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InmuebleId",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
