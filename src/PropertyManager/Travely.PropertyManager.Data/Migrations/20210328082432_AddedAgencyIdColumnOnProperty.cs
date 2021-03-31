using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.PropertyManager.Data.Migrations
{
    public partial class AddedAgencyIdColumnOnProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "Property",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "Property");
        }
    }
}
