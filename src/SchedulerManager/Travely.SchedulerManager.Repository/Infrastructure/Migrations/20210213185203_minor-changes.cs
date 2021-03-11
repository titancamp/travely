using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.SchedulerManager.Repository.Infrastructure.Migrations
{
    public partial class minorchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "UserSchedules",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "ScheduleInfos",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "MessageTemplates",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserSchedules",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "ScheduleInfos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "MessageTemplates",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserSchedules",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ScheduleInfos",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "MessageTemplates",
                newName: "Active");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "ScheduleInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "MessageTemplates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
