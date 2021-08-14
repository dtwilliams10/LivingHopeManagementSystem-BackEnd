using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LHMSAPI.Migrations
{
    public partial class ChangedSystemStatustoSystemReportStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemStatus_SystemReportStatusId",
                table: "SystemReports");

            migrationBuilder.DropTable(
                name: "SystemStatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "SystemReportStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemReportStatus", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SystemReports_SystemReportStatus_SystemReportStatusId",
                table: "SystemReports",
                column: "SystemReportStatusId",
                principalTable: "SystemReportStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemReports_SystemReportStatus_SystemReportStatusId",
                table: "SystemReports");

            migrationBuilder.DropTable(
                name: "SystemReportStatus");

            migrationBuilder.CreateTable(
                name: "SystemStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    emailAddress = table.Column<string>(type: "text", nullable: true),
                    firstName = table.Column<string>(type: "text", nullable: true),
                    lastName = table.Column<string>(type: "text", nullable: true),
                    passwordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    passwordSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SystemReports_SystemStatus_SystemReportStatusId",
                table: "SystemReports",
                column: "SystemReportStatusId",
                principalTable: "SystemStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
