using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LHMS.SystemReports.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    SystemName = table.Column<int>(nullable: false),
                    SystemUpdate = table.Column<string>(nullable: true),
                    PersonnelUpdates = table.Column<string>(nullable: true),
                    CreativeIdeasAndEvaluations = table.Column<string>(nullable: true),
                    BarriersOrChallenges = table.Column<string>(nullable: true),
                    HowCanIHelpYou = table.Column<string>(nullable: true),
                    PersonalGrowthAndDevelopment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemReports");
        }
    }
}
