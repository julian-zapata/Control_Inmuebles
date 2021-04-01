using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class addnewInmuebles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseInmueble");

            migrationBuilder.DropTable(
                name: "DptoInmueble");

            migrationBuilder.DropTable(
                name: "PisoInmueble");

            migrationBuilder.DropTable(
                name: "TipoInmueble");

            migrationBuilder.DropColumn(
                name: "GaranteId",
                table: "Contrato");

            migrationBuilder.AddColumn<int>(
                name: "Garante1",
                table: "Contrato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Garante2",
                table: "Contrato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Casa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(maxLength: 30, nullable: false),
                    Numero = table.Column<string>(maxLength: 5, nullable: false),
                    Barrio = table.Column<string>(maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    Observacion = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cochera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(maxLength: 30, nullable: false),
                    Numero = table.Column<string>(maxLength: 5, nullable: false),
                    Barrio = table.Column<string>(maxLength: 20, nullable: false),
                    NumCochera = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cochera", x => x.Id);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casa");

            migrationBuilder.DropTable(
                name: "Cochera");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Edificio");

            migrationBuilder.DropColumn(
                name: "Garante1",
                table: "Contrato");

            migrationBuilder.DropColumn(
                name: "Garante2",
                table: "Contrato");

            migrationBuilder.AddColumn<int>(
                name: "GaranteId",
                table: "Contrato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BaseInmueble",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TipoInmuebleId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: true),
                    DptoInmuebleId = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaisId = table.Column<int>(type: "int", nullable: true),
                    PisoInmuebleId = table.Column<int>(type: "int", nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseInmueble", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DptoInmueble",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseInmuebleId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PisoInmuebleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DptoInmueble", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PisoInmueble",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseInmuebleId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PisoInmueble", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoInmueble",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInmueble", x => x.Id);
                });
        }
    }
}
