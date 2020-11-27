using Microsoft.EntityFrameworkCore.Migrations;

namespace CountryAPI_API.Migrations
{
    public partial class UniqueCountryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Country_CountryName",
                table: "Country",
                column: "CountryName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Country_CountryName",
                table: "Country");
        }
    }
}
