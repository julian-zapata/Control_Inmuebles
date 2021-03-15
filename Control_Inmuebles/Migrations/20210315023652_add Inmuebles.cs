using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class addInmuebles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseInmueble",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoInmuebleId = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 20, nullable: false),
                    Numero = table.Column<int>(maxLength: 5, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    PisoInmuebleId = table.Column<int>(nullable: true),
                    DptoInmuebleId = table.Column<int>(nullable: true),
                    CiudadId = table.Column<int>(nullable: true),
                    ProvinciaId = table.Column<int>(nullable: true),
                    PaisId = table.Column<int>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseInmueble", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DptoInmueble",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 20, nullable: false),
                    BaseInmuebleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DptoInmueble", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PisoInmueble",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 20, nullable: false),
                    BaseInmuebleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PisoInmueble", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoInmueble",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInmueble", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseInmueble");

            migrationBuilder.DropTable(
                name: "DptoInmueble");

            migrationBuilder.DropTable(
                name: "PisoInmueble");

            migrationBuilder.DropTable(
                name: "TipoInmueble");
        }
    }
}
