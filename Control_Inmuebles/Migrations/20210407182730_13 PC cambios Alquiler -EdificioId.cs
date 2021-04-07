using Microsoft.EntityFrameworkCore.Migrations;

namespace Control_Inmuebles.Migrations
{
    public partial class _13PCcambiosAlquilerEdificioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EdificioId",
                table: "Alquiler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EdificioId",
                table: "Alquiler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
