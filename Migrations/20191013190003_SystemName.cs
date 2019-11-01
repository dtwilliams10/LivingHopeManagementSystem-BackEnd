using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LHMSAPI.Migrations
{
    public partial class SystemName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemName",
                table: "SystemReports");

            migrationBuilder.DropColumn(
                name: "SystemReportStatus",
                table: "SystemReports");

            migrationBuilder.AddColumn<int>(
                name: "SystemReportId",
                table: "SystemStatus",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SystemName",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    SystemReportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemName_SystemReports_SystemReportId",
                        column: x => x.SystemReportId,
                        principalTable: "SystemReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemStatus_SystemReportId",
                table: "SystemStatus",
                column: "SystemReportId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemName_SystemReportId",
                table: "SystemName",
                column: "SystemReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemStatus_SystemReports_SystemReportId",
                table: "SystemStatus",
                column: "SystemReportId",
                principalTable: "SystemReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemStatus_SystemReports_SystemReportId",
                table: "SystemStatus");

            migrationBuilder.DropTable(
                name: "SystemName");

            migrationBuilder.DropIndex(
                name: "IX_SystemStatus_SystemReportId",
                table: "SystemStatus");

            migrationBuilder.DropColumn(
                name: "SystemReportId",
                table: "SystemStatus");

            migrationBuilder.AddColumn<int>(
                name: "SystemName",
                table: "SystemReports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SystemReportStatus",
                table: "SystemReports",
                nullable: false,
                defaultValue: 0);
        }
    }
}
