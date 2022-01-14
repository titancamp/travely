using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travely.SupplierManager.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccommodationTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationTypeEntity", x => x.Id);
                });

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
                name: "FoodTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuideTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideTypeEntity", x => x.Id);
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
                name: "RegionEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportationTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationTypeEntity", x => x.Id);
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
                name: "AccommodationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
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
                        name: "FK_AccommodationEntity_AccommodationTypeEntity_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AccommodationTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccommodationEntity_LocationEntity_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccommodationEntity_RegionEntity_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionEntity",
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
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_FoodEntity_FoodTypeEntity_TypeId",
                        column: x => x.TypeId,
                        principalTable: "FoodTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_FoodEntity_RegionEntity_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionEntity",
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
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_GuidesEntity_GuideTypeEntity_TypeId",
                        column: x => x.TypeId,
                        principalTable: "GuideTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuidesEntity_LocationEntity_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuidesEntity_RegionEntity_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionEntity",
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
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_TransportationEntity_RegionEntity_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportationEntity_TransportationTypeEntity_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TransportationTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationServiceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationServiceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccommodationServiceEntity_AccommodationEntity_AccommodationEntityId",
                        column: x => x.AccommodationEntityId,
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
                    TypeId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_RoomEntity_RoomTypeEntity_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RoomTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AccommodationEntityId = table.Column<int>(type: "int", nullable: true),
                    ActivitiesEntityId = table.Column<int>(type: "int", nullable: true),
                    FoodEntityId = table.Column<int>(type: "int", nullable: true),
                    GuidesEntityId = table.Column<int>(type: "int", nullable: true),
                    MenuEntityId = table.Column<int>(type: "int", nullable: true),
                    TransportationEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity_AccommodationEntity_AccommodationEntityId",
                        column: x => x.AccommodationEntityId,
                        principalTable: "AccommodationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity_ActivitiesEntity_ActivitiesEntityId",
                        column: x => x.ActivitiesEntityId,
                        principalTable: "ActivitiesEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity_FoodEntity_FoodEntityId",
                        column: x => x.FoodEntityId,
                        principalTable: "FoodEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity_GuidesEntity_GuidesEntityId",
                        column: x => x.GuidesEntityId,
                        principalTable: "GuidesEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity_MenuEntity_MenuEntityId",
                        column: x => x.MenuEntityId,
                        principalTable: "MenuEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttachmentEntity_TransportationEntity_TransportationEntityId",
                        column: x => x.TransportationEntityId,
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
                name: "RoomServiceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "GuideEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuidesEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuideEntity_AttachmentEntity_ImageId",
                        column: x => x.ImageId,
                        principalTable: "AttachmentEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuideEntity_GuidesEntity_GuidesEntityId",
                        column: x => x.GuidesEntityId,
                        principalTable: "GuidesEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicenseTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseTypeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseTypeEntity_DriverEntity_DriverEntityId",
                        column: x => x.DriverEntityId,
                        principalTable: "DriverEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverEntityId = table.Column<int>(type: "int", nullable: true),
                    GuideEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageEntity_DriverEntity_DriverEntityId",
                        column: x => x.DriverEntityId,
                        principalTable: "DriverEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageEntity_GuideEntity_GuideEntityId",
                        column: x => x.GuideEntityId,
                        principalTable: "GuideEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationEntity_LocationId",
                table: "AccommodationEntity",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationEntity_RegionId",
                table: "AccommodationEntity",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationEntity_TypeId",
                table: "AccommodationEntity",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationServiceEntity_AccommodationEntityId",
                table: "AccommodationServiceEntity",
                column: "AccommodationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity_AccommodationEntityId",
                table: "AttachmentEntity",
                column: "AccommodationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity_ActivitiesEntityId",
                table: "AttachmentEntity",
                column: "ActivitiesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity_FoodEntityId",
                table: "AttachmentEntity",
                column: "FoodEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity_GuidesEntityId",
                table: "AttachmentEntity",
                column: "GuidesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity_MenuEntityId",
                table: "AttachmentEntity",
                column: "MenuEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntity_TransportationEntityId",
                table: "AttachmentEntity",
                column: "TransportationEntityId");

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
                name: "IX_FoodEntity_RegionId",
                table: "FoodEntity",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntity_TypeId",
                table: "FoodEntity",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GuideEntity_GuidesEntityId",
                table: "GuideEntity",
                column: "GuidesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_GuideEntity_ImageId",
                table: "GuideEntity",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidesEntity_LocationId",
                table: "GuidesEntity",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidesEntity_RegionId",
                table: "GuidesEntity",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidesEntity_TypeId",
                table: "GuidesEntity",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity_DriverEntityId",
                table: "LanguageEntity",
                column: "DriverEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity_GuideEntityId",
                table: "LanguageEntity",
                column: "GuideEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseTypeEntity_DriverEntityId",
                table: "LicenseTypeEntity",
                column: "DriverEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomEntity_AccommodationEntityId",
                table: "RoomEntity",
                column: "AccommodationEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomEntity_TypeId",
                table: "RoomEntity",
                column: "TypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TransportationEntity_RegionId",
                table: "TransportationEntity",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationEntity_TypeId",
                table: "TransportationEntity",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationServiceEntity");

            migrationBuilder.DropTable(
                name: "AttributeEntity");

            migrationBuilder.DropTable(
                name: "CarEntity");

            migrationBuilder.DropTable(
                name: "LanguageEntity");

            migrationBuilder.DropTable(
                name: "LicenseTypeEntity");

            migrationBuilder.DropTable(
                name: "RoomServiceEntity");

            migrationBuilder.DropTable(
                name: "TagEntity");

            migrationBuilder.DropTable(
                name: "GuideEntity");

            migrationBuilder.DropTable(
                name: "DriverEntity");

            migrationBuilder.DropTable(
                name: "RoomEntity");

            migrationBuilder.DropTable(
                name: "AttachmentEntity");

            migrationBuilder.DropTable(
                name: "RoomTypeEntity");

            migrationBuilder.DropTable(
                name: "AccommodationEntity");

            migrationBuilder.DropTable(
                name: "ActivitiesEntity");

            migrationBuilder.DropTable(
                name: "FoodEntity");

            migrationBuilder.DropTable(
                name: "GuidesEntity");

            migrationBuilder.DropTable(
                name: "TransportationEntity");

            migrationBuilder.DropTable(
                name: "AccommodationTypeEntity");

            migrationBuilder.DropTable(
                name: "FoodTypeEntity");

            migrationBuilder.DropTable(
                name: "MenuEntity");

            migrationBuilder.DropTable(
                name: "GuideTypeEntity");

            migrationBuilder.DropTable(
                name: "LocationEntity");

            migrationBuilder.DropTable(
                name: "RegionEntity");

            migrationBuilder.DropTable(
                name: "TransportationTypeEntity");
        }
    }
}
