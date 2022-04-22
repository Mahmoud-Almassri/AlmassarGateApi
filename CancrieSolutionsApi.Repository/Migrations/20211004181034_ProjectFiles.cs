using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlmassarGateApi.Repository.Migrations
{
    public partial class ProjectFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ElectricityPhaseEndDate",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ElectricityPhaseStartDate",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinancialProposalProof",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IronPhaseEndDate",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "IronPhaseStartDate",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectEndDate",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectStartDate",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicalProposalProof",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<long>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<long>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    FileCategory = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFiles_ApplicationUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectFiles_ApplicationUser_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectFiles_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_CreatedById",
                table: "ProjectFiles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_ModifiedById",
                table: "ProjectFiles",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_ProjectId",
                table: "ProjectFiles",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFiles");

            migrationBuilder.DropColumn(
                name: "ElectricityPhaseEndDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ElectricityPhaseStartDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "FinancialProposalProof",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IronPhaseEndDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IronPhaseStartDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectEndDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectStartDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TechnicalProposalProof",
                table: "Project");
        }
    }
}
