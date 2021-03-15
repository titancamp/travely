using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.ClientManager.Repository.Migrations
{
    public partial class addedIsMainColumnInTourist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Tourist",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Tourist");
        }
    }
}
