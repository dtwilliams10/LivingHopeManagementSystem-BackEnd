﻿// <auto-generated />
using LHMS.SystemReports.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SystemReports.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
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
                        .HasName("pk_sr_system_names_lkp");

                    b.ToTable("sr.system_names_lkp");
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

                    b.Property<string>("ReporterId")
                        .HasColumnType("text")
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
                        .HasName("pk_sr_system_reports");

                    b.HasIndex("SystemNameId")
                        .HasDatabaseName("ix_sr_system_reports_system_name_id");

                    b.HasIndex("SystemReportStatusId")
                        .HasDatabaseName("ix_sr_system_reports_system_report_status_id");

                    b.ToTable("sr.system_reports");
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
                        .HasName("pk_sr_system_report_status_lkp");

                    b.ToTable("sr.system_report_status_lkp");
                });

            modelBuilder.Entity("LHMS.SystemReports.Entities.SystemReport", b =>
                {
                    b.HasOne("LHMS.SystemReports.Entities.SystemName", "SystemName")
                        .WithMany("SystemReports")
                        .HasForeignKey("SystemNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_sr_system_reports_sr_system_names_lkp_system_name_id");

                    b.HasOne("LHMS.SystemReports.Entities.SystemReportStatus", "SystemReportStatus")
                        .WithMany()
                        .HasForeignKey("SystemReportStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_sr_system_reports_sr_system_report_status_lkp_system_report");

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
