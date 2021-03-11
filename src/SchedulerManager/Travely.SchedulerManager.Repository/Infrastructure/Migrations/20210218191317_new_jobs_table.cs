using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.SchedulerManager.Repository.Infrastructure.Migrations
{
    public partial class new_jobs_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateName",
                table: "MessageTemplates");

            migrationBuilder.AddColumn<int>(
                name: "TemplateType",
                table: "MessageTemplates",
                type: "int",
                maxLength: 250,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ScheduleJobs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleInfoId = table.Column<long>(type: "bigint", nullable: false),
                    JobId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FireDate = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleJobs_Schedule",
                        column: x => x.ScheduleInfoId,
                        principalTable: "ScheduleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleJobs_ScheduleInfoId",
                table: "ScheduleJobs",
                column: "ScheduleInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleJobs");

            migrationBuilder.DropColumn(
                name: "TemplateType",
                table: "MessageTemplates");

            migrationBuilder.AddColumn<string>(
                name: "TemplateName",
                table: "MessageTemplates",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
