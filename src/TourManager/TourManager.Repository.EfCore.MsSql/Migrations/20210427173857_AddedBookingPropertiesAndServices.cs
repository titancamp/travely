using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TourManager.Repository.EfCore.MsSql.Migrations
{
    public partial class AddedBookingPropertiesAndServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalFlightNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CancellationDeadline",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CheckOutDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DepartureFlightNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Origin",
                table: "Bookings",
                newName: "BookingService");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Bookings",
                newName: "BookingProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingService",
                table: "Bookings",
                newName: "Origin");

            migrationBuilder.RenameColumn(
                name: "BookingProperty",
                table: "Bookings",
                newName: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalFlightNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ArrivalTime",
                table: "Bookings",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "CancellationDeadline",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DepartureFlightNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DepartureTime",
                table: "Bookings",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
