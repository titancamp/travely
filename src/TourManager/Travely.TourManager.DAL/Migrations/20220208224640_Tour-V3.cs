using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.TourManager.DAL.Migrations
{
    public partial class TourV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TourTypeId",
                table: "Tour",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tour_TourTypeId",
                table: "Tour",
                column: "TourTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_TourType_TourTypeId",
                table: "Tour",
                column: "TourTypeId",
                principalTable: "TourType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_TourType_TourTypeId",
                table: "Tour");

            migrationBuilder.DropIndex(
                name: "IX_Tour_TourTypeId",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "TourTypeId",
                table: "Tour");
        }
    }
}
