using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.SupplierManager.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivitiesEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesEntity", x => x.Id);
                });

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
                name: "MenuEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentEntity<ActivitiesEntity>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentEntity<ActivitiesEntity>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity<ActivitiesEntity>_ActivitiesEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "ActivitiesEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttributeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ActivitiesEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeEntity_ActivitiesEntity_ActivitiesEntityId",
                        column: x => x.ActivitiesEntityId,
                        principalTable: "ActivitiesEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TmRegion = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllInclusive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastEditedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                name: "GuidesEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TmRegion = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidesEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuidesEntity_LocationEntity_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TmRegion = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastEditedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportationEntity_LocationEntity_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentEntity<MenuEntity>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentEntity<MenuEntity>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity<MenuEntity>_MenuEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "MenuEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TmRegion = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    WorkingDays = table.Column<bool>(type: "bit", nullable: false),
                    OpeningHoursWd = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClosingHoursWd = table.Column<TimeSpan>(type: "time", nullable: false),
                    Weekends = table.Column<bool>(type: "bit", nullable: false),
                    OpeningHoursW = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClosingHoursW = table.Column<TimeSpan>(type: "time", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodEntity_LocationEntity_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodEntity_MenuEntity_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MenuEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MenuEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagEntity_MenuEntity_MenuEntityId",
                        column: x => x.MenuEntityId,
                        principalTable: "MenuEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationServiceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service = table.Column<int>(type: "int", nullable: false),
                    AccommodationId = table.Column<int>(type: "int", nullable: true)
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
                name: "AttachmentEntity<AccommodationEntity>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentEntity<AccommodationEntity>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity<AccommodationEntity>_AccommodationEntity_UserId",
                        column: x => x.UserId,
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
                    Type = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
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
                name: "AttachmentEntity<GuidesEntity>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentEntity<GuidesEntity>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity<GuidesEntity>_GuidesEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "GuidesEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuideEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuidesEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuideEntity_GuidesEntity_GuidesEntityId",
                        column: x => x.GuidesEntityId,
                        principalTable: "GuidesEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentEntity<TransportationEntity>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentEntity<TransportationEntity>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity<TransportationEntity>_TransportationEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "TransportationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    NumberOfCarSeats = table.Column<int>(type: "int", nullable: false),
                    TransportationEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarEntity_TransportationEntity_TransportationEntityId",
                        column: x => x.TransportationEntityId,
                        principalTable: "TransportationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DriverEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportationEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverEntity_TransportationEntity_TransportationEntityId",
                        column: x => x.TransportationEntityId,
                        principalTable: "TransportationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentEntity<FoodEntity>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentEntity<FoodEntity>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity<FoodEntity>_FoodEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "FoodEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomServiceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service = table.Column<int>(type: "int", nullable: false),
                    RoomEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServiceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomServiceEntity_RoomEntity_RoomEntityId",
                        column: x => x.RoomEntityId,
                        principalTable: "RoomEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguageEntity<GuideEntity>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageEntity<GuideEntity>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageEntity<GuideEntity>_GuideEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "GuideEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguageEntity<DriverEntity>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageEntity<DriverEntity>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageEntity<DriverEntity>_DriverEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "DriverEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicenseTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseType = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseTypeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseTypeEntity_DriverEntity_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DriverEntity",
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
                name: "IX_AttachmentEntity<AccommodationEntity>_UserId",
                table: "AttachmentEntity<AccommodationEntity>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity<ActivitiesEntity>_UserId",
                table: "AttachmentEntity<ActivitiesEntity>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity<FoodEntity>_UserId",
                table: "AttachmentEntity<FoodEntity>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity<GuidesEntity>_UserId",
                table: "AttachmentEntity<GuidesEntity>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity<MenuEntity>_UserId",
                table: "AttachmentEntity<MenuEntity>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity<TransportationEntity>_UserId",
                table: "AttachmentEntity<TransportationEntity>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeEntity_ActivitiesEntityId",
                table: "AttributeEntity",
                column: "ActivitiesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CarEntity_TransportationEntityId",
                table: "CarEntity",
                column: "TransportationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverEntity_TransportationEntityId",
                table: "DriverEntity",
                column: "TransportationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntity_LocationId",
                table: "FoodEntity",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntity_MenuId",
                table: "FoodEntity",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_GuideEntity_GuidesEntityId",
                table: "GuideEntity",
                column: "GuidesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidesEntity_LocationId",
                table: "GuidesEntity",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity<DriverEntity>_UserId",
                table: "LanguageEntity<DriverEntity>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity<GuideEntity>_UserId",
                table: "LanguageEntity<GuideEntity>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseTypeEntity_DriverId",
                table: "LicenseTypeEntity",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomEntity_AccommodationEntityId",
                table: "RoomEntity",
                column: "AccommodationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceEntity_RoomEntityId",
                table: "RoomServiceEntity",
                column: "RoomEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TagEntity_MenuEntityId",
                table: "TagEntity",
                column: "MenuEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationEntity_LocationId",
                table: "TransportationEntity",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationServiceEntity");

            migrationBuilder.DropTable(
                name: "AttachmentEntity<AccommodationEntity>");

            migrationBuilder.DropTable(
                name: "AttachmentEntity<ActivitiesEntity>");

            migrationBuilder.DropTable(
                name: "AttachmentEntity<FoodEntity>");

            migrationBuilder.DropTable(
                name: "AttachmentEntity<GuidesEntity>");

            migrationBuilder.DropTable(
                name: "AttachmentEntity<MenuEntity>");

            migrationBuilder.DropTable(
                name: "AttachmentEntity<TransportationEntity>");

            migrationBuilder.DropTable(
                name: "AttributeEntity");

            migrationBuilder.DropTable(
                name: "CarEntity");

            migrationBuilder.DropTable(
                name: "LanguageEntity<DriverEntity>");

            migrationBuilder.DropTable(
                name: "LanguageEntity<GuideEntity>");

            migrationBuilder.DropTable(
                name: "LicenseTypeEntity");

            migrationBuilder.DropTable(
                name: "RoomServiceEntity");

            migrationBuilder.DropTable(
                name: "TagEntity");

            migrationBuilder.DropTable(
                name: "FoodEntity");

            migrationBuilder.DropTable(
                name: "ActivitiesEntity");

            migrationBuilder.DropTable(
                name: "GuideEntity");

            migrationBuilder.DropTable(
                name: "DriverEntity");

            migrationBuilder.DropTable(
                name: "RoomEntity");

            migrationBuilder.DropTable(
                name: "MenuEntity");

            migrationBuilder.DropTable(
                name: "GuidesEntity");

            migrationBuilder.DropTable(
                name: "TransportationEntity");

            migrationBuilder.DropTable(
                name: "AccommodationEntity");

            migrationBuilder.DropTable(
                name: "LocationEntity");
        }
    }
}
