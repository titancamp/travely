using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.IdentityManager.Repository.EntityFramework.Migrations
{
    public partial class AgencyPhoneNmber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Agency",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Agency");
        }
    }
}
