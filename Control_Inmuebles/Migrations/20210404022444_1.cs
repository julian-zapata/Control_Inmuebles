using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alquiler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdificioId = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    InquilinoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CobroCuotaDepartamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCobro = table.Column<DateTime>(nullable: false),
                    InquilinoId = table.Column<int>(nullable: false),
                    ContratoDepartamento = table.Column<int>(nullable: false),
                    Edificio = table.Column<int>(nullable: false),
                    Piso = table.Column<int>(nullable: false),
                    dpto = table.Column<int>(nullable: false),
                    CoutaAlquiler = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CuotaAgua = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CoutaMunicipal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CoutaRentas = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MotivoBaja = table.Column<string>(nullable: true),
                    FechaBajaAnticipoContrato = table.Column<DateTime>(nullable: false),
                    AlquileresAdeudados = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroCuotaDepartamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropietarioId = table.Column<int>(nullable: false),
                    InquilinoId = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    PlazoContrato = table.Column<int>(nullable: false),
                    CuotaMensualPrimerAño = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AumentoCuotaSegundoAño = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AumentoCuotaTercerAño = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Garante1 = table.Column<int>(nullable: false),
                    Garante2 = table.Column<int>(nullable: false),
                    InmobiliariaId = table.Column<int>(nullable: false),
                    AltaContrato = table.Column<DateTime>(nullable: false),
                    NumContrato = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdificioId = table.Column<int>(nullable: false),
                    Piso = table.Column<string>(nullable: false),
                    Dpto = table.Column<string>(nullable: false),
                    Ambientes = table.Column<string>(nullable: false),
                    Observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edificio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(maxLength: 30, nullable: false),
                    Numero = table.Column<string>(maxLength: 5, nullable: false),
                    Barrio = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edificio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(maxLength: 12, nullable: false),
                    Dni = table.Column<string>(maxLength: 12, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Domicilio = table.Column<string>(maxLength: 30, nullable: false),
                    Numero = table.Column<string>(maxLength: 5, nullable: false),
                    Piso = table.Column<string>(maxLength: 5, nullable: true),
                    Departamento = table.Column<string>(maxLength: 1, nullable: true),
                    Barrio = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false),
                    Provincia = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: true),
                    Nota = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Impuesto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Periodo = table.Column<string>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TipoImpuestoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impuesto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inquilino",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(maxLength: 12, nullable: false),
                    Dni = table.Column<string>(maxLength: 12, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Domicilio = table.Column<string>(maxLength: 30, nullable: false),
                    Numero = table.Column<string>(maxLength: 5, nullable: false),
                    Piso = table.Column<string>(maxLength: 5, nullable: true),
                    Departamento = table.Column<string>(maxLength: 1, nullable: true),
                    Barrio = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false),
                    Provincia = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: true),
                    Nota = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquilino", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(maxLength: 12, nullable: false),
                    Dni = table.Column<string>(maxLength: 12, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Domicilio = table.Column<string>(maxLength: 30, nullable: false),
                    Numero = table.Column<string>(maxLength: 5, nullable: false),
                    Piso = table.Column<string>(maxLength: 5, nullable: true),
                    Departamento = table.Column<string>(maxLength: 1, nullable: true),
                    Barrio = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false),
                    Provincia = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: true),
                    Nota = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Periodo = table.Column<string>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TipoServicioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoImpuesto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoImpuesto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquiler");

            migrationBuilder.DropTable(
                name: "CobroCuotaDepartamento");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Edificio");

            migrationBuilder.DropTable(
                name: "Garante");

            migrationBuilder.DropTable(
                name: "Impuesto");

            migrationBuilder.DropTable(
                name: "Inquilino");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "TipoImpuesto");

            migrationBuilder.DropTable(
                name: "TipoServicio");
        }
    }
}
