using Microsoft.EntityFrameworkCore.Migrations;

namespace LHMS.SystemReports.Migrations
{
    public partial class RemoveActiveField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "SystemReports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "SystemReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
