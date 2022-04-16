using Microsoft.EntityFrameworkCore.Migrations;

namespace LHMS.SystemReports.Migrations
{
    public partial class ReporterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SystemReports");

            migrationBuilder.AddColumn<string>(
                name: "ReportName",
                table: "SystemReports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReporterName",
                table: "SystemReports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportName",
                table: "SystemReports");

            migrationBuilder.DropColumn(
                name: "ReporterName",
                table: "SystemReports");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SystemReports",
                type: "text",
                nullable: true);
        }
    }
}
