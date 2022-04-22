using Microsoft.EntityFrameworkCore.Migrations;

namespace AlmassarGateApi.Repository.Migrations
{
    public partial class QuestionGroupTitleIdModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GroupTitleId",
                table: "ChecklistQuestion",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GroupTitleId",
                table: "ChecklistQuestion",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
