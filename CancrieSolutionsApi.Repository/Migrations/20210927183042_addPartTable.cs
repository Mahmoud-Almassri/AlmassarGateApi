using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlmassarGateApi.Repository.Migrations
{
    public partial class addPartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedById1 = table.Column<long>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true),
                    ModifiedById1 = table.Column<long>(nullable: true),
                    PartNumber = table.Column<string>(nullable: true),
                    PartName = table.Column<string>(nullable: true),
                    Available = table.Column<int>(nullable: false),
                    PriceForUnit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_ApplicationUser_CreatedById1",
                        column: x => x.CreatedById1,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parts_ApplicationUser_ModifiedById1",
                        column: x => x.ModifiedById1,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CreatedById1",
                table: "Parts",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ModifiedById1",
                table: "Parts",
                column: "ModifiedById1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");
        }
    }
}
