﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travely.TourManager.DAL;

namespace Travely.TourManager.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220208224640_Tour-V3")]
    partial class TourV3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Travely.TourManager.DAL.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("IsDeleted");

                    b.Property<string>("PartnerName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PartnerName");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TourName");

                    b.Property<int>("TourTypeId")
                        .HasColumnType("int")
                        .HasColumnName("TourTypeId");

                    b.HasKey("Id");

                    b.HasIndex("TourTypeId");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("Travely.TourManager.DAL.TourType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TypeName");

                    b.HasKey("Id");

                    b.ToTable("TourType");
                });

            modelBuilder.Entity("Travely.TourManager.DAL.Tour", b =>
                {
                    b.HasOne("Travely.TourManager.DAL.TourType", "TourType")
                        .WithMany("Tours")
                        .HasForeignKey("TourTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TourType");
                });

            modelBuilder.Entity("Travely.TourManager.DAL.TourType", b =>
                {
                    b.Navigation("Tours");
                });
#pragma warning restore 612, 618
        }
    }
}
