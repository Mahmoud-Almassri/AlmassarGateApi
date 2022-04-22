using Microsoft.EntityFrameworkCore.Migrations;

namespace AlmassarGateApi.Repository.Migrations
{
    public partial class fixCreatedByAndModifidByCoulmns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_ApplicationUser_CreatedById1",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_ApplicationUser_ModifiedById1",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Approval_ApplicationUser_CreatedById1",
                table: "Approval");

            migrationBuilder.DropForeignKey(
                name: "FK_Approval_ApplicationUser_ModifiedById1",
                table: "Approval");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistAnswer_ApplicationUser_CreatedById1",
                table: "ChecklistAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistAnswer_ApplicationUser_ModifiedById1",
                table: "ChecklistAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistQuestion_ApplicationUser_CreatedById1",
                table: "ChecklistQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistQuestion_ApplicationUser_ModifiedById1",
                table: "ChecklistQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_ApplicationUser_CreatedById1",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_ApplicationUser_ModifiedById1",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ApplicationUser_CreatedById1",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ApplicationUser_ModifiedById1",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ApplicationUser_CreatedById1",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ApplicationUser_ModifiedById1",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_ApplicationUser_CreatedById1",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_ApplicationUser_ModifiedById1",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_CreatedById1",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_ModifiedById1",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Project_CreatedById1",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ModifiedById1",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Parts_CreatedById1",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_ModifiedById1",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Group_CreatedById1",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_ModifiedById1",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistQuestion_CreatedById1",
                table: "ChecklistQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistQuestion_ModifiedById1",
                table: "ChecklistQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistAnswer_CreatedById1",
                table: "ChecklistAnswer");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistAnswer_ModifiedById1",
                table: "ChecklistAnswer");

            migrationBuilder.DropIndex(
                name: "IX_Approval_CreatedById1",
                table: "Approval");

            migrationBuilder.DropIndex(
                name: "IX_Approval_ModifiedById1",
                table: "Approval");

            migrationBuilder.DropIndex(
                name: "IX_Actions_CreatedById1",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_ModifiedById1",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "ModifiedById1",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ModifiedById1",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ModifiedById1",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "ModifiedById1",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "ChecklistQuestion");

            migrationBuilder.DropColumn(
                name: "ModifiedById1",
                table: "ChecklistQuestion");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "ChecklistAnswer");

            migrationBuilder.DropColumn(
                name: "ModifiedById1",
                table: "ChecklistAnswer");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "Approval");

            migrationBuilder.DropColumn(
                name: "ModifiedById1",
                table: "Approval");

            migrationBuilder.DropColumn(
                name: "CreatedById1",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "ModifiedById1",
                table: "Actions");

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "Task",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Task",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "Parts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Parts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "Group",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Group",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "ChecklistQuestion",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "ChecklistQuestion",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "ChecklistAnswer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "ChecklistAnswer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "Approval",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Approval",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModifiedById",
                table: "Actions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Actions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_CreatedById",
                table: "Task",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ModifiedById",
                table: "Task",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedById",
                table: "Project",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ModifiedById",
                table: "Project",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CreatedById",
                table: "Parts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ModifiedById",
                table: "Parts",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Group_CreatedById",
                table: "Group",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Group_ModifiedById",
                table: "Group",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistQuestion_CreatedById",
                table: "ChecklistQuestion",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistQuestion_ModifiedById",
                table: "ChecklistQuestion",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistAnswer_CreatedById",
                table: "ChecklistAnswer",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistAnswer_ModifiedById",
                table: "ChecklistAnswer",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Approval_CreatedById",
                table: "Approval",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Approval_ModifiedById",
                table: "Approval",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CreatedById",
                table: "Actions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ModifiedById",
                table: "Actions",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_ApplicationUser_CreatedById",
                table: "Actions",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_ApplicationUser_ModifiedById",
                table: "Actions",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Approval_ApplicationUser_CreatedById",
                table: "Approval",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Approval_ApplicationUser_ModifiedById",
                table: "Approval",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistAnswer_ApplicationUser_CreatedById",
                table: "ChecklistAnswer",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistAnswer_ApplicationUser_ModifiedById",
                table: "ChecklistAnswer",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistQuestion_ApplicationUser_CreatedById",
                table: "ChecklistQuestion",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistQuestion_ApplicationUser_ModifiedById",
                table: "ChecklistQuestion",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_ApplicationUser_CreatedById",
                table: "Group",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_ApplicationUser_ModifiedById",
                table: "Group",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ApplicationUser_CreatedById",
                table: "Parts",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ApplicationUser_ModifiedById",
                table: "Parts",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Task_ApplicationUser_CreatedById",
                table: "Task",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_ApplicationUser_ModifiedById",
                table: "Task",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_ApplicationUser_CreatedById",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_ApplicationUser_ModifiedById",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Approval_ApplicationUser_CreatedById",
                table: "Approval");

            migrationBuilder.DropForeignKey(
                name: "FK_Approval_ApplicationUser_ModifiedById",
                table: "Approval");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistAnswer_ApplicationUser_CreatedById",
                table: "ChecklistAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistAnswer_ApplicationUser_ModifiedById",
                table: "ChecklistAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistQuestion_ApplicationUser_CreatedById",
                table: "ChecklistQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistQuestion_ApplicationUser_ModifiedById",
                table: "ChecklistQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_ApplicationUser_CreatedById",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_ApplicationUser_ModifiedById",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ApplicationUser_CreatedById",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_ApplicationUser_ModifiedById",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ApplicationUser_CreatedById",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ApplicationUser_ModifiedById",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_ApplicationUser_CreatedById",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_ApplicationUser_ModifiedById",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_CreatedById",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_ModifiedById",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Project_CreatedById",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ModifiedById",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Parts_CreatedById",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_ModifiedById",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Group_CreatedById",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_ModifiedById",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistQuestion_CreatedById",
                table: "ChecklistQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistQuestion_ModifiedById",
                table: "ChecklistQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistAnswer_CreatedById",
                table: "ChecklistAnswer");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistAnswer_ModifiedById",
                table: "ChecklistAnswer");

            migrationBuilder.DropIndex(
                name: "IX_Approval_CreatedById",
                table: "Approval");

            migrationBuilder.DropIndex(
                name: "IX_Approval_ModifiedById",
                table: "Approval");

            migrationBuilder.DropIndex(
                name: "IX_Actions_CreatedById",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_ModifiedById",
                table: "Actions");

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedById",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById1",
                table: "Task",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedById1",
                table: "Task",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedById",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById1",
                table: "Project",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedById1",
                table: "Project",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedById",
                table: "Parts",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Parts",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById1",
                table: "Parts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedById1",
                table: "Parts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedById",
                table: "Group",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Group",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById1",
                table: "Group",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedById1",
                table: "Group",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedById",
                table: "ChecklistQuestion",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "ChecklistQuestion",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById1",
                table: "ChecklistQuestion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedById1",
                table: "ChecklistQuestion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedById",
                table: "ChecklistAnswer",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "ChecklistAnswer",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById1",
                table: "ChecklistAnswer",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedById1",
                table: "ChecklistAnswer",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedById",
                table: "Approval",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Approval",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById1",
                table: "Approval",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedById1",
                table: "Approval",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModifiedById",
                table: "Actions",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "Actions",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById1",
                table: "Actions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedById1",
                table: "Actions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_CreatedById1",
                table: "Task",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ModifiedById1",
                table: "Task",
                column: "ModifiedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedById1",
                table: "Project",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ModifiedById1",
                table: "Project",
                column: "ModifiedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CreatedById1",
                table: "Parts",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ModifiedById1",
                table: "Parts",
                column: "ModifiedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Group_CreatedById1",
                table: "Group",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Group_ModifiedById1",
                table: "Group",
                column: "ModifiedById1");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistQuestion_CreatedById1",
                table: "ChecklistQuestion",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistQuestion_ModifiedById1",
                table: "ChecklistQuestion",
                column: "ModifiedById1");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistAnswer_CreatedById1",
                table: "ChecklistAnswer",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistAnswer_ModifiedById1",
                table: "ChecklistAnswer",
                column: "ModifiedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Approval_CreatedById1",
                table: "Approval",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Approval_ModifiedById1",
                table: "Approval",
                column: "ModifiedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CreatedById1",
                table: "Actions",
                column: "CreatedById1");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ModifiedById1",
                table: "Actions",
                column: "ModifiedById1");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_ApplicationUser_CreatedById1",
                table: "Actions",
                column: "CreatedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_ApplicationUser_ModifiedById1",
                table: "Actions",
                column: "ModifiedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Approval_ApplicationUser_CreatedById1",
                table: "Approval",
                column: "CreatedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Approval_ApplicationUser_ModifiedById1",
                table: "Approval",
                column: "ModifiedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistAnswer_ApplicationUser_CreatedById1",
                table: "ChecklistAnswer",
                column: "CreatedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistAnswer_ApplicationUser_ModifiedById1",
                table: "ChecklistAnswer",
                column: "ModifiedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistQuestion_ApplicationUser_CreatedById1",
                table: "ChecklistQuestion",
                column: "CreatedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistQuestion_ApplicationUser_ModifiedById1",
                table: "ChecklistQuestion",
                column: "ModifiedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_ApplicationUser_CreatedById1",
                table: "Group",
                column: "CreatedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_ApplicationUser_ModifiedById1",
                table: "Group",
                column: "ModifiedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ApplicationUser_CreatedById1",
                table: "Parts",
                column: "CreatedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_ApplicationUser_ModifiedById1",
                table: "Parts",
                column: "ModifiedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ApplicationUser_CreatedById1",
                table: "Project",
                column: "CreatedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ApplicationUser_ModifiedById1",
                table: "Project",
                column: "ModifiedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_ApplicationUser_CreatedById1",
                table: "Task",
                column: "CreatedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_ApplicationUser_ModifiedById1",
                table: "Task",
                column: "ModifiedById1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
