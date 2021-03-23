using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class deleteTipoInmuebleIdonPisoInmueblesclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoInmuebleId",
                table: "PisoInmueble");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoInmuebleId",
                table: "PisoInmueble",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
