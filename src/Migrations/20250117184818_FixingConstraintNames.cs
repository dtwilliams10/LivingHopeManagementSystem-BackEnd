using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemReports.Migrations
{
    /// <inheritdoc />
    public partial class FixingConstraintNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sr_system_reports_sr_system_report_status_lkp_system_report",
                table: "sr.system_reports");

            migrationBuilder.DropIndex(
                name: "ix_sr_system_reports_system_report_status_id",
                table: "sr.system_reports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_sr_system_reports_system_report_status_id",
                table: "sr.system_reports",
                column: "system_report_status_id");

            migrationBuilder.AddForeignKey(
                name: "fk_sr_system_reports_sr_system_report_status_lkp_system_report",
                table: "sr.system_reports",
                column: "system_report_status_id",
                principalTable: "sr.system_report_status_lkp",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
