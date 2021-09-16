﻿// <auto-generated />
using System;
using LHMS.SystemReports.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LHMS.SystemReports.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200207232058_AuthenticationAPI")]
    partial class AuthenticationAPI
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LHMS.SystemReportsEntities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("firstName")
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .HasColumnType("text");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("passwordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LHMS.SystemReportsModels.SystemName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SystemName");
                });

            modelBuilder.Entity("LHMS.SystemReportsModels.SystemReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("BarriersOrChallenges")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreativeIdeasAndEvaluations")
                        .HasColumnType("text");

                    b.Property<string>("HowCanIHelpYou")
                        .HasColumnType("text");

                    b.Property<string>("PersonalGrowthAndDevelopment")
                        .HasColumnType("text");

                    b.Property<string>("PersonnelUpdates")
                        .HasColumnType("text");

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ReportName")
                        .HasColumnType("text");

                    b.Property<string>("ReporterName")
                        .HasColumnType("text");

                    b.Property<int>("SystemNameId")
                        .HasColumnType("integer");

                    b.Property<int>("SystemReportStatusId")
                        .HasColumnType("integer");

                    b.Property<string>("SystemUpdate")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("SystemNameId");

                    b.HasIndex("SystemReportStatusId");

                    b.ToTable("SystemReports");
                });

            modelBuilder.Entity("LHMS.SystemReportsModels.SystemStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SystemStatus");
                });

            modelBuilder.Entity("LHMS.SystemReportsModels.SystemReport", b =>
                {
                    b.HasOne("LHMS.SystemReportsModels.SystemName", "SystemName")
                        .WithMany("SystemReports")
                        .HasForeignKey("SystemNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LHMS.SystemReportsModels.SystemStatus", "SystemReportStatus")
                        .WithMany()
                        .HasForeignKey("SystemReportStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
