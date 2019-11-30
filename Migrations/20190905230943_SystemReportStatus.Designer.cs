﻿// <auto-generated />
using System;
using LHMSAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LHMSAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190905230943_SystemReportStatus")]
    partial class SystemReportStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SystemReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BarriersOrChallenges");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreativeIdeasAndEvaluations");

                    b.Property<string>("HowCanIHelpYou");

                    b.Property<string>("Name");

                    b.Property<string>("PersonalGrowthAndDevelopment");

                    b.Property<string>("PersonnelUpdates");

                    b.Property<DateTime>("ReportDate");

                    b.Property<int>("SystemName");

                    b.Property<int>("SystemReportStatus");

                    b.Property<string>("SystemUpdate");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("SystemReports");
                });
#pragma warning restore 612, 618
        }
    }
}