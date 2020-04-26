using Microsoft.EntityFrameworkCore.Migrations;

namespace CyrillicAny.Data.Migrations
{
    public partial class SearchModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Query",
                table: "Queries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Query",
                table: "Queries");
        }
    }
}
