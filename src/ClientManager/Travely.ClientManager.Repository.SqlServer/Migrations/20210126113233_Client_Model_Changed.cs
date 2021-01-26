using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.ClientManager.Repository.SqlServer.Migrations
{
    public partial class Client_Model_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Preference",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Client",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "PassportId",
                table: "Client",
                newName: "PlaceOfBirth");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Client",
                newName: "PassportNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Client",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Client",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IssuedBy",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedDate",
                table: "Client",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IssuedBy",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IssuedDate",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Preference",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "PlaceOfBirth",
                table: "Client",
                newName: "PassportId");

            migrationBuilder.RenameColumn(
                name: "PassportNumber",
                table: "Client",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Client",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
