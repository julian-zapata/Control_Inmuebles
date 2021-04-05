using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class cambiosdemovimientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contrato",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "AlquileresAdeudados",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "ContratoDepartamento",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "FechaBajaAnticipoContrato",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "InquilinoId",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "MotivoBaja",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "EdificioId",
                table: "Alquiler");

            migrationBuilder.DropColumn(
                name: "InquilinoId",
                table: "Alquiler");

            migrationBuilder.DropColumn(
                name: "AumentoCuotaSegundoAño",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "AumentoCuotaTercerAño",
                table: "Contrato");

            migrationBuilder.RenameTable(
                name: "Contrato",
                newName: "ContratoDepartamento");

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Propietario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Inquilino",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Garante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContratoDepartamentoId",
                table: "CobroCuotaDepartamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Inquilino",
                table: "CobroCuotaDepartamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContratoDepartamentoId",
                table: "Alquiler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAgua",
                table: "Alquiler",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorMunicipalidad",
                table: "Alquiler",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorRentas",
                table: "Alquiler",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "EdificioId",
                table: "ContratoDepartamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContratoDepartamento",
                table: "ContratoDepartamento",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContratoDepartamento",
                table: "ContratoDepartamento");

            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Propietario");

            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Inquilino");

            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Garante");

            migrationBuilder.DropColumn(
                name: "ContratoDepartamentoId",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "Inquilino",
                table: "CobroCuotaDepartamento");

            migrationBuilder.DropColumn(
                name: "ContratoDepartamentoId",
                table: "Alquiler");

            migrationBuilder.DropColumn(
                name: "ValorAgua",
                table: "Alquiler");

            migrationBuilder.DropColumn(
                name: "ValorMunicipalidad",
                table: "Alquiler");

            migrationBuilder.DropColumn(
                name: "ValorRentas",
                table: "Alquiler");

            migrationBuilder.DropColumn(
                name: "EdificioId",
                table: "ContratoDepartamento");

            migrationBuilder.RenameTable(
                name: "ContratoDepartamento",
                newName: "Contrato");

            migrationBuilder.AddColumn<decimal>(
                name: "AlquileresAdeudados",
                table: "CobroCuotaDepartamento",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ContratoDepartamento",
                table: "CobroCuotaDepartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBajaAnticipoContrato",
                table: "CobroCuotaDepartamento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InquilinoId",
                table: "CobroCuotaDepartamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MotivoBaja",
                table: "CobroCuotaDepartamento",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdificioId",
                table: "Alquiler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InquilinoId",
                table: "Alquiler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AumentoCuotaSegundoAño",
                table: "Contrato",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AumentoCuotaTercerAño",
                table: "Contrato",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contrato",
                table: "Contrato",
                column: "Id");
        }
    }
}
