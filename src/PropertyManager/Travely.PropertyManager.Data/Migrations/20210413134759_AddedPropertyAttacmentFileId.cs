using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.PropertyManager.Data.Migrations
{
    public partial class AddedPropertyAttacmentFileId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "PropertyAttachment");

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "PropertyAttachment",
                type: "varchar(36)",
                unicode: false,
                maxLength: 36,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "PropertyAttachment");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "PropertyAttachment",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);
        }
    }
}
