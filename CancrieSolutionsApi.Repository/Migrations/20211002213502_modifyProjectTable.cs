using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlmassarGateApi.Repository.Migrations
{
    public partial class modifyProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approval_Project_ProjectId",
                table: "Approval");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ApplicationUser_CreatedById",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ApplicationUser_ModifiedById",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_CreatedById",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ModifiedById",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Approval_ProjectId",
                table: "Approval");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Project");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                table: "Project",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Project",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedById",
                table: "Project",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Project",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedById",
                table: "Project",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ModifiedById",
                table: "Project",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Approval_ProjectId",
                table: "Approval",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approval_Project_ProjectId",
                table: "Approval",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ApplicationUser_CreatedById",
                table: "Project",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ApplicationUser_ModifiedById",
                table: "Project",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
