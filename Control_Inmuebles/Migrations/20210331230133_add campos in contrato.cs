using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class addcamposincontrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClausuraContrato",
                table: "Contrato");

            migrationBuilder.AlterColumn<string>(
                name: "Inmueble",
                table: "Contrato",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CasaId",
                table: "Contrato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CocheraId",
                table: "Contrato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Contrato",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CasaId",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "CocheraId",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Contrato");

            migrationBuilder.AlterColumn<string>(
                name: "Inmueble",
                table: "Contrato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "ClausuraContrato",
                table: "Contrato",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
