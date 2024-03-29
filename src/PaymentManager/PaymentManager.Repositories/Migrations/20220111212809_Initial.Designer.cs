﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentManager.Repositories.DbContexts;

namespace PaymentManager.Repositories.Migrations
{
    [DbContext(typeof(PaymentDbContext))]
    [Migration("20220111212809_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaymentManager.Repositories.Entities.PayableEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("ActualCost")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Difference")
                        .HasColumnType("decimal(20,2)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasAttachment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("PaidAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,2)")
                        .HasDefaultValue(0m);

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentType")
                        .HasColumnType("int");

                    b.Property<decimal>("PlannedCost")
                        .HasColumnType("decimal(20,2)");

                    b.Property<decimal?>("Remaining")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(5);

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TourStatus")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PayableEntity");
                });

            modelBuilder.Entity("PaymentManager.Repositories.Entities.PayableItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("AttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InvoiceId")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int?>("PayableId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PayableId");

                    b.ToTable("PayableItems");
                });

            modelBuilder.Entity("PaymentManager.Repositories.Entities.ReceivableEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasAttachment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("InvoiceSent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("PaidAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("PartnerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentType")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(20,2)");

                    b.Property<decimal>("Remaining")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(5);

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(20,2)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TourStatus")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ReceivableEntity");
                });

            modelBuilder.Entity("PaymentManager.Repositories.Entities.ReceivableItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("AttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InvoiceId")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("InvoiceSent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("decimal(20,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<int?>("ReceivableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceivableId");

                    b.ToTable("ReceivableItems");
                });

            modelBuilder.Entity("PaymentManager.Repositories.Entities.PayableItemEntity", b =>
                {
                    b.HasOne("PaymentManager.Repositories.Entities.PayableEntity", "Payable")
                        .WithMany("PayableItems")
                        .HasForeignKey("PayableId");

                    b.Navigation("Payable");
                });

            modelBuilder.Entity("PaymentManager.Repositories.Entities.ReceivableItemEntity", b =>
                {
                    b.HasOne("PaymentManager.Repositories.Entities.ReceivableEntity", "Receivable")
                        .WithMany("ReceivableItems")
                        .HasForeignKey("ReceivableId");

                    b.Navigation("Receivable");
                });

            modelBuilder.Entity("PaymentManager.Repositories.Entities.PayableEntity", b =>
                {
                    b.Navigation("PayableItems");
                });

            modelBuilder.Entity("PaymentManager.Repositories.Entities.ReceivableEntity", b =>
                {
                    b.Navigation("ReceivableItems");
                });
#pragma warning restore 612, 618
        }
    }
}
