﻿// <auto-generated />
using LHMS.SystemReports.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SystemReports.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221027105613_ChangedReporterNametoReporterid")]
    partial class ChangedReporterNametoReporterid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LHMS.SystemReports.Entities.SystemName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_system_names");

                    b.ToTable("system_names", (string)null);
                });

            modelBuilder.Entity("LHMS.SystemReports.Entities.SystemReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BarriersOrChallenges")
                        .HasColumnType("text")
                        .HasColumnName("barriers_or_challenges");

                    b.Property<Instant>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("CreativeIdeasAndEvaluations")
                        .HasColumnType("text")
                        .HasColumnName("creative_ideas_and_evaluations");

                    b.Property<string>("HowCanIHelpYou")
                        .HasColumnType("text")
                        .HasColumnName("how_can_i_help_you");

                    b.Property<string>("PersonalGrowthAndDevelopment")
                        .HasColumnType("text")
                        .HasColumnName("personal_growth_and_development");

                    b.Property<string>("PersonnelUpdates")
                        .HasColumnType("text")
                        .HasColumnName("personnel_updates");

                    b.Property<Instant>("ReportDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("report_date");

                    b.Property<string>("ReportName")
                        .HasColumnType("text")
                        .HasColumnName("report_name");

                    b.Property<int>("ReporterId")
                        .HasColumnType("integer")
                        .HasColumnName("reporter_id");

                    b.Property<int>("SystemNameId")
                        .HasColumnType("integer")
                        .HasColumnName("system_name_id");

                    b.Property<int>("SystemReportStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("system_report_status_id");

                    b.Property<string>("SystemUpdate")
                        .HasColumnType("text")
                        .HasColumnName("system_update");

                    b.Property<Instant>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id")
                        .HasName("pk_system_reports");

                    b.HasIndex("SystemNameId")
                        .HasDatabaseName("ix_system_reports_system_name_id");

                    b.HasIndex("SystemReportStatusId")
                        .HasDatabaseName("ix_system_reports_system_report_status_id");

                    b.ToTable("system_reports", (string)null);
                });

            modelBuilder.Entity("LHMS.SystemReports.Entities.SystemReportStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_system_report_status");

                    b.ToTable("system_report_status", (string)null);
                });

            modelBuilder.Entity("LHMS.SystemReports.Entities.SystemReport", b =>
                {
                    b.HasOne("LHMS.SystemReports.Entities.SystemName", "SystemName")
                        .WithMany("SystemReports")
                        .HasForeignKey("SystemNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_system_reports_system_names_system_name_id");

                    b.HasOne("LHMS.SystemReports.Entities.SystemReportStatus", "SystemReportStatus")
                        .WithMany()
                        .HasForeignKey("SystemReportStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_system_reports_system_report_status_system_report_status_id");

                    b.Navigation("SystemName");

                    b.Navigation("SystemReportStatus");
                });

            modelBuilder.Entity("LHMS.SystemReports.Entities.SystemName", b =>
                {
                    b.Navigation("SystemReports");
                });
#pragma warning restore 612, 618
        }
    }
}
