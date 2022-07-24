using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace deila.backend.Migrations
{
    public partial class fixederror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Basiss",
                columns: new[] { "Id", "Category", "Incidents" },
                values: new object[,]
                {
                    { 1, "Gender", 0 },
                    { 2, "Race", 0 },
                    { 3, "Disability", 0 },
                    { 4, "Other", 0 }
                });
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
