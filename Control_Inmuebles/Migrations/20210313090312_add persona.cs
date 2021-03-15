using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class addpersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 12, nullable: false),
                    Apellido = table.Column<string>(maxLength: 12, nullable: false),
                    Dni = table.Column<string>(maxLength: 12, nullable: false),
                    Domicilio = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(maxLength: 5, nullable: false),
                    Piso = table.Column<int>(maxLength: 5, nullable: false),
                    Departamento = table.Column<string>(maxLength: 1, nullable: false),
                    Barrio = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false),
                    Provincia = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inquilino",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 12, nullable: false),
                    Apellido = table.Column<string>(maxLength: 12, nullable: false),
                    Dni = table.Column<string>(maxLength: 12, nullable: false),
                    Domicilio = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(maxLength: 5, nullable: false),
                    Piso = table.Column<int>(maxLength: 5, nullable: false),
                    Departamento = table.Column<string>(maxLength: 1, nullable: false),
                    Barrio = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false),
                    Provincia = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: true)
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
                    Nombre = table.Column<string>(maxLength: 12, nullable: false),
                    Apellido = table.Column<string>(maxLength: 12, nullable: false),
                    Dni = table.Column<string>(maxLength: 12, nullable: false),
                    Domicilio = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(maxLength: 5, nullable: false),
                    Piso = table.Column<int>(maxLength: 5, nullable: false),
                    Departamento = table.Column<string>(maxLength: 1, nullable: false),
                    Barrio = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: false),
                    Provincia = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garante");

            migrationBuilder.DropTable(
                name: "Inquilino");

            migrationBuilder.DropTable(
                name: "Propietario");
        }
    }
}
