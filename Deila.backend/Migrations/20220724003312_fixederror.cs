using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace deila.backend.Migrations
{
    public partial class fixederror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Basiss",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Basiss",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Basiss",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Basiss",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
