using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.SchedulerManager.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageTemplateId = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecurseId = table.Column<int>(type: "int", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_MessageTemplate",
                        column: x => x.MessageTemplateId,
                        principalTable: "MessageTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleInfoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSchedule_Schedule",
                        column: x => x.ScheduleInfoId,
                        principalTable: "ScheduleInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleInfos_MessageTemplateId",
                table: "ScheduleInfos",
                column: "MessageTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSchedules_ScheduleInfoId",
                table: "UserSchedules",
                column: "ScheduleInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSchedules");

            migrationBuilder.DropTable(
                name: "ScheduleInfos");

            migrationBuilder.DropTable(
                name: "MessageTemplates");
        }
    }
}
