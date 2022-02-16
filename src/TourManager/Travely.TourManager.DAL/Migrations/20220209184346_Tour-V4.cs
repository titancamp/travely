using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.TourManager.DAL.Migrations
{
    public partial class TourV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Tour",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ArrivalFlightNumber",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalLocation",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ArrivalTime",
                table: "Tour",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Tour",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DepartureFlightNumber",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartureLocation",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DepartureTime",
                table: "Tour",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Tour",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Tour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Tour",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TourStatusId",
                table: "Tour",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TourStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tour_TourStatusId",
                table: "Tour",
                column: "TourStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_TourStatus_TourStatusId",
                table: "Tour",
                column: "TourStatusId",
                principalTable: "TourStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_TourStatus_TourStatusId",
                table: "Tour");

            migrationBuilder.DropTable(
                name: "TourStatus");

            migrationBuilder.DropIndex(
                name: "IX_Tour_TourStatusId",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "ArrivalFlightNumber",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "ArrivalLocation",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "DepartureFlightNumber",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "DepartureLocation",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "TourStatusId",
                table: "Tour");
        }
    }
}
