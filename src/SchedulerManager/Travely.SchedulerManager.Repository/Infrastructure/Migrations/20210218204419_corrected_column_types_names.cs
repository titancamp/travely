using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.SchedulerManager.Repository.Infrastructure.Migrations
{
    public partial class corrected_column_types_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemplateType",
                table: "MessageTemplates",
                newName: "TemplateName");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "UserSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                table: "ScheduleJobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FireDate",
                table: "ScheduleJobs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<long>(
                name: "RecurseId",
                table: "ScheduleInfos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemplateName",
                table: "MessageTemplates",
                newName: "TemplateType");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "UserSchedules",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "JobId",
                table: "ScheduleJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "FireDate",
                table: "ScheduleJobs",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "RecurseId",
                table: "ScheduleInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
