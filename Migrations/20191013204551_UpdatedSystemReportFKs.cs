using Microsoft.EntityFrameworkCore.Migrations;

namespace LHMSAPI.Migrations
{
    public partial class UpdatedSystemReportFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemName_SystemNameId",
                table: "SystemReports");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemStatus_SystemReportStatusId",
                table: "SystemReports");

            migrationBuilder.AlterColumn<int>(
                name: "SystemReportStatusId",
                table: "SystemReports",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SystemNameId",
                table: "SystemReports",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemReports_SystemName_SystemNameId",
                table: "SystemReports",
                column: "SystemNameId",
                principalTable: "SystemName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemReports_SystemStatus_SystemReportStatusId",
                table: "SystemReports",
                column: "SystemReportStatusId",
                principalTable: "SystemStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemName_SystemNameId",
                table: "SystemReports");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemStatus_SystemReportStatusId",
                table: "SystemReports");

            migrationBuilder.AlterColumn<int>(
                name: "SystemReportStatusId",
                table: "SystemReports",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SystemNameId",
                table: "SystemReports",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
