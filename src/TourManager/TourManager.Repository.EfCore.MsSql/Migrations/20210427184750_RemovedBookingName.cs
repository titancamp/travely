using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManager.Repository.EfCore.MsSql.Migrations
{
    public partial class RemovedBookingName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
