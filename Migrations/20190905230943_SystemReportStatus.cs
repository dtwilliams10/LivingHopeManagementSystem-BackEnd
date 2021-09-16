using Microsoft.EntityFrameworkCore.Migrations;

namespace LHMS.SystemReports.Migrations
{
    public partial class SystemReportStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemReportStatus",
                table: "SystemReports",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemReportStatus",
                table: "SystemReports");
        }
    }
}
