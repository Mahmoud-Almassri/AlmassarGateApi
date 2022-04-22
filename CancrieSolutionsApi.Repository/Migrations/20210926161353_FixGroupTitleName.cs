using Microsoft.EntityFrameworkCore.Migrations;

namespace AlmassarGateApi.Repository.Migrations
{
    public partial class FixGroupTitleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupTitleName",
                table: "ChecklistQuestion");

            migrationBuilder.AddColumn<string>(
                name: "GroupTitleId",
                table: "ChecklistQuestion",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupTitleId",
                table: "ChecklistQuestion");

            migrationBuilder.AddColumn<string>(
                name: "GroupTitleName",
                table: "ChecklistQuestion",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
