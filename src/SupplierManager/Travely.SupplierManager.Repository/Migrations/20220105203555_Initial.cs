using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.SupplierManager.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    CheckInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllInclusive = table.Column<bool>(type: "bit", nullable: false),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccommodationEntity_LocationEntity_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationServiceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccommodationId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationServiceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccommodationServiceEntity_AccommodationEntity_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "AccommodationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccommodationId = table.Column<int>(type: "int", nullable: true),
                    AttachmentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity_AccommodationEntity_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "AccommodationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                    AdditionalBeds = table.Column<int>(type: "int", nullable: false),
                    AccommodationEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomEntity_AccommodationEntity_AccommodationEntityId",
                        column: x => x.AccommodationEntityId,
                        principalTable: "AccommodationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomServiceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServiceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomServiceEntity_RoomEntity_RoomId",
                        column: x => x.RoomId,
                        principalTable: "RoomEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationEntity_LocationId",
                table: "AccommodationEntity",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationServiceEntity_AccommodationId",
                table: "AccommodationServiceEntity",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity_AccommodationId",
                table: "AttachmentEntity",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomEntity_AccommodationEntityId",
                table: "RoomEntity",
                column: "AccommodationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceEntity_RoomId",
                table: "RoomServiceEntity",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationServiceEntity");

            migrationBuilder.DropTable(
                name: "AttachmentEntity");

            migrationBuilder.DropTable(
                name: "RoomServiceEntity");

            migrationBuilder.DropTable(
                name: "RoomEntity");

            migrationBuilder.DropTable(
                name: "AccommodationEntity");

            migrationBuilder.DropTable(
                name: "LocationEntity");
        }
    }
}
