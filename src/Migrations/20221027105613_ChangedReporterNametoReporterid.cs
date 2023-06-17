using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemReports.Migrations
{
    public partial class ChangedReporterNametoReporterid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reporter_name",
                table: "system_reports");

            migrationBuilder.AddColumn<int>(
                name: "reporter_id",
                table: "system_reports",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reporter_id",
                table: "system_reports");

            migrationBuilder.AddColumn<string>(
                name: "reporter_name",
                table: "system_reports",
                type: "text",
                nullable: true);
        }
    }
}
