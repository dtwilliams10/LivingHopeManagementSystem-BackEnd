using Microsoft.EntityFrameworkCore.Migrations;

namespace LHMSAPI.Migrations
{
    public partial class ActiveIndicator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "SystemReports",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "SystemReports");
        }
    }
}
