using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SystemReports.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "system_report_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_system_report_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SystemNames",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_system_names", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "system_reports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reporter_name = table.Column<string>(type: "text", nullable: true),
                    report_name = table.Column<string>(type: "text", nullable: true),
                    report_date = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    created_date = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    system_report_status_id = table.Column<int>(type: "integer", nullable: false),
                    system_name_id = table.Column<int>(type: "integer", nullable: false),
                    system_update = table.Column<string>(type: "text", nullable: true),
                    personnel_updates = table.Column<string>(type: "text", nullable: true),
                    creative_ideas_and_evaluations = table.Column<string>(type: "text", nullable: true),
                    barriers_or_challenges = table.Column<string>(type: "text", nullable: true),
                    how_can_i_help_you = table.Column<string>(type: "text", nullable: true),
                    personal_growth_and_development = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_system_reports", x => x.id);
                    table.ForeignKey(
                        name: "fk_system_reports_system_names_system_name_id",
                        column: x => x.system_name_id,
                        principalTable: "SystemNames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_system_reports_system_report_status_system_report_status_id",
                        column: x => x.system_report_status_id,
                        principalTable: "system_report_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_system_reports_system_name_id",
                table: "system_reports",
                column: "system_name_id");

            migrationBuilder.CreateIndex(
                name: "ix_system_reports_system_report_status_id",
                table: "system_reports",
                column: "system_report_status_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "system_reports");

            migrationBuilder.DropTable(
                name: "SystemNames");

            migrationBuilder.DropTable(
                name: "system_report_status");
        }
    }
}
