using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemReports.Migrations
{
    public partial class fixed_system_names_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "SystemNames",
                newName: "system_names");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "system_names",
                newName: "SystemNames");
        }
    }
}
