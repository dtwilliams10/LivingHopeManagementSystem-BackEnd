using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LHMS.SystemReports.Migrations
{
    public partial class UpdateSystemNameToSystemNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemName_SystemNameId",
                table: "SystemReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemName",
                table: "SystemName");

            migrationBuilder.RenameTable(
                name: "SystemName",
                newName: "SystemNames");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "SystemReports",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportDate",
                table: "SystemReports",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemReports",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemNames",
                table: "SystemNames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemReports_SystemNames_SystemNameId",
                table: "SystemReports",
                column: "SystemNameId",
                principalTable: "SystemNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemNames_SystemNameId",
                table: "SystemReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemNames",
                table: "SystemNames");

            migrationBuilder.RenameTable(
                name: "SystemNames",
                newName: "SystemName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "SystemReports",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportDate",
                table: "SystemReports",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SystemReports",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemName",
                table: "SystemName",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemReports_SystemName_SystemNameId",
                table: "SystemReports",
                column: "SystemNameId",
                principalTable: "SystemName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
