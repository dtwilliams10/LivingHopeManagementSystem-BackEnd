using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemReports.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableNameSpaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_system_reports_system_names_system_name_id",
                table: "system_reports");

            migrationBuilder.DropForeignKey(
                name: "fk_system_reports_system_report_status_system_report_status_id",
                table: "system_reports");

            migrationBuilder.DropPrimaryKey(
                name: "pk_system_reports",
                table: "system_reports");

            migrationBuilder.DropPrimaryKey(
                name: "pk_system_report_status",
                table: "system_report_status");

            migrationBuilder.DropPrimaryKey(
                name: "pk_system_names",
                table: "system_names");

            migrationBuilder.RenameTable(
                name: "system_reports",
                newName: "sr.system_reports");

            migrationBuilder.RenameTable(
                name: "system_report_status",
                newName: "sr.system_report_status_lkp");

            migrationBuilder.RenameTable(
                name: "system_names",
                newName: "sr.system_names_lkp");

            migrationBuilder.RenameIndex(
                name: "ix_system_reports_system_report_status_id",
                table: "sr.system_reports",
                newName: "ix_sr_system_reports_system_report_status_id");

            migrationBuilder.RenameIndex(
                name: "ix_system_reports_system_name_id",
                table: "sr.system_reports",
                newName: "ix_sr_system_reports_system_name_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sr_system_reports",
                table: "sr.system_reports",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sr_system_report_status_lkp",
                table: "sr.system_report_status_lkp",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sr_system_names_lkp",
                table: "sr.system_names_lkp",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sr_system_reports_sr_system_names_lkp_system_name_id",
                table: "sr.system_reports",
                column: "system_name_id",
                principalTable: "sr.system_names_lkp",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sr_system_reports_sr_system_report_status_lkp_system_report",
                table: "sr.system_reports",
                column: "system_report_status_id",
                principalTable: "sr.system_report_status_lkp",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sr_system_reports_sr_system_names_lkp_system_name_id",
                table: "sr.system_reports");

            migrationBuilder.DropForeignKey(
                name: "fk_sr_system_reports_sr_system_report_status_lkp_system_report",
                table: "sr.system_reports");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sr_system_reports",
                table: "sr.system_reports");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sr_system_report_status_lkp",
                table: "sr.system_report_status_lkp");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sr_system_names_lkp",
                table: "sr.system_names_lkp");

            migrationBuilder.RenameTable(
                name: "sr.system_reports",
                newName: "system_reports");

            migrationBuilder.RenameTable(
                name: "sr.system_report_status_lkp",
                newName: "system_report_status");

            migrationBuilder.RenameTable(
                name: "sr.system_names_lkp",
                newName: "system_names");

            migrationBuilder.RenameIndex(
                name: "ix_sr_system_reports_system_report_status_id",
                table: "system_reports",
                newName: "ix_system_reports_system_report_status_id");

            migrationBuilder.RenameIndex(
                name: "ix_sr_system_reports_system_name_id",
                table: "system_reports",
                newName: "ix_system_reports_system_name_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_system_reports",
                table: "system_reports",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_system_report_status",
                table: "system_report_status",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_system_names",
                table: "system_names",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_system_reports_system_names_system_name_id",
                table: "system_reports",
                column: "system_name_id",
                principalTable: "system_names",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_system_reports_system_report_status_system_report_status_id",
                table: "system_reports",
                column: "system_report_status_id",
                principalTable: "system_report_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
