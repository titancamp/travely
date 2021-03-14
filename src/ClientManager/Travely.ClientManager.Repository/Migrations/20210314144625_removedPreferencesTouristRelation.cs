using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.ClientManager.Repository.Migrations
{
    public partial class removedPreferencesTouristRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreferenceTourist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreferenceTourist",
                columns: table => new
                {
                    PreferencesId = table.Column<int>(type: "int", nullable: false),
                    TouristsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceTourist", x => new { x.PreferencesId, x.TouristsId });
                    table.ForeignKey(
                        name: "FK_PreferenceTourist_Preference_PreferencesId",
                        column: x => x.PreferencesId,
                        principalTable: "Preference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferenceTourist_Tourist_TouristsId",
                        column: x => x.TouristsId,
                        principalTable: "Tourist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceTourist_TouristsId",
                table: "PreferenceTourist",
                column: "TouristsId");
        }
    }
}
