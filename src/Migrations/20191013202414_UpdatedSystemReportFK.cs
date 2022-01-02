using Microsoft.EntityFrameworkCore.Migrations;

namespace LHMS.SystemReports.Migrations
{
    public partial class UpdatedSystemReportFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemName_SystemReports_SystemReportId",
                table: "SystemName");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemStatus_SystemReports_SystemReportId",
                table: "SystemStatus");

            migrationBuilder.DropIndex(
                name: "IX_SystemStatus_SystemReportId",
                table: "SystemStatus");

            migrationBuilder.DropIndex(
                name: "IX_SystemName_SystemReportId",
                table: "SystemName");

            migrationBuilder.DropColumn(
                name: "SystemReportId",
                table: "SystemStatus");

            migrationBuilder.DropColumn(
                name: "SystemReportId",
                table: "SystemName");

            migrationBuilder.AddColumn<int>(
                name: "SystemNameId",
                table: "SystemReports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SystemReportStatusId",
                table: "SystemReports",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemReports_SystemNameId",
                table: "SystemReports",
                column: "SystemNameId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemReports_SystemReportStatusId",
                table: "SystemReports",
                column: "SystemReportStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemReports_SystemName_SystemNameId",
                table: "SystemReports",
                column: "SystemNameId",
                principalTable: "SystemName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemReports_SystemStatus_SystemReportStatusId",
                table: "SystemReports",
                column: "SystemReportStatusId",
                principalTable: "SystemStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemName_SystemNameId",
                table: "SystemReports");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemStatus_SystemReportStatusId",
                table: "SystemReports");

            migrationBuilder.DropIndex(
                name: "IX_SystemReports_SystemNameId",
                table: "SystemReports");

            migrationBuilder.DropIndex(
                name: "IX_SystemReports_SystemReportStatusId",
                table: "SystemReports");

            migrationBuilder.DropColumn(
                name: "SystemNameId",
                table: "SystemReports");

            migrationBuilder.DropColumn(
                name: "SystemReportStatusId",
                table: "SystemReports");

            migrationBuilder.AddColumn<int>(
                name: "SystemReportId",
                table: "SystemStatus",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SystemReportId",
                table: "SystemName",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemStatus_SystemReportId",
                table: "SystemStatus",
                column: "SystemReportId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemName_SystemReportId",
                table: "SystemName",
                column: "SystemReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemName_SystemReports_SystemReportId",
                table: "SystemName",
                column: "SystemReportId",
                principalTable: "SystemReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemStatus_SystemReports_SystemReportId",
                table: "SystemStatus",
                column: "SystemReportId",
                principalTable: "SystemReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
