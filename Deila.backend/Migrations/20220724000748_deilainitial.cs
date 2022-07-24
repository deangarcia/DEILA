using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace deila.backend.Migrations
{
    public partial class deilainitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Basiss");
        }
    }
}
