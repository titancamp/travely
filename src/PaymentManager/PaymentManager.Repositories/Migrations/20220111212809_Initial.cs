using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentManager.Repositories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayableEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    TourName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TourStatus = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlannedCost = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    ActualCost = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
                    Difference = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false, defaultValue: 0m),
                    Remaining = table.Column<decimal>(type: "decimal(20,2)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 5),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: true),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceivableEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    TourName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TourStatus = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    PartnerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false, defaultValue: 0m),
                    Remaining = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 5),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: true),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InvoiceSent = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivableEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayableItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayableId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayableItems_PayableEntity_PayableId",
                        column: x => x.PayableId,
                        principalTable: "PayableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceivableItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivableId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceSent = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivableItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivableItems_ReceivableEntity_ReceivableId",
                        column: x => x.ReceivableId,
                        principalTable: "ReceivableEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayableItems_PayableId",
                table: "PayableItems",
                column: "PayableId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivableItems_ReceivableId",
                table: "ReceivableItems",
                column: "ReceivableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayableItems");

            migrationBuilder.DropTable(
                name: "ReceivableItems");

            migrationBuilder.DropTable(
                name: "PayableEntity");

            migrationBuilder.DropTable(
                name: "ReceivableEntity");
        }
    }
}
