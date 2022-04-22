using Microsoft.EntityFrameworkCore.Migrations;

namespace AlmassarGateApi.Repository.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "MobileNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegId", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { 1L, 0, "83532a81-1d3d-434e-93a4-5728210ae2d7", null, null, "Mahmoud-Al-Massri@hotmail.com", false, null, false, true, null, null, "Mahmoud-Al-Massri@hotmail.com", "ADMIN", "AQAAAAEAACcQAAAAELr73GmhxCifQepLABo6ilVa+fVkEu+M40P4tfg2C5xiBxeEROKT2xfyxcIoU57roQ==", "0790809158", false, null, "RCWSSGGSUGXLM4LBICRGPK75IGT77DIY", false, null, null, "ADMIN" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "Key", "ModifiedById", "ModifiedDate", "ParentId", "Status", "Value" },
                values: new object[,]
                {
                    { 1, null, null, "specsFileName", null, null, 2, 1, 1 },
                    { 19, null, null, "projectEndDate", null, null, 2, 1, 19 },
                    { 18, null, null, "projectStartDate", null, null, 2, 1, 18 },
                    { 17, null, null, "electricityPhaseEndDate", null, null, 2, 1, 17 },
                    { 16, null, null, "electricityPhaseStartDate", null, null, 2, 1, 16 },
                    { 14, null, null, "ironPhaseStartDate", null, null, 2, 1, 14 },
                    { 13, null, null, "financialProposalProof", null, null, 2, 1, 13 },
                    { 12, null, null, "technicalProposalProof", null, null, 2, 1, 12 },
                    { 11, null, null, "subStatus", null, null, 2, 1, 11 },
                    { 15, null, null, "ironPhaseEndDate", null, null, 2, 1, 15 },
                    { 9, null, null, "technicalProposalFileName", null, null, 2, 1, 9 },
                    { 10, null, null, "financialProposalFileName", null, null, 2, 1, 10 },
                    { 3, null, null, "paymentTermsFileName", null, null, 2, 1, 3 },
                    { 4, null, null, "numberOfPanels", null, null, 2, 1, 4 },
                    { 5, null, null, "designReference", null, null, 2, 1, 5 },
                    { 2, null, null, "layoutFileName", null, null, 2, 1, 2 },
                    { 7, null, null, "clientName", null, null, 2, 1, 7 },
                    { 8, null, null, "projectGuid", null, null, 2, 1, 8 },
                    { 6, null, null, "projectName", null, null, 2, 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 8L, null, "Sales", "Sales" },
                    { 1L, null, "Admin", "Admin" },
                    { 2L, null, "Client", "Client" },
                    { 3L, null, "Production", "Production" },
                    { 4L, null, "Design", "Design" },
                    { 5L, null, "Repository", "Repository" },
                    { 6L, null, "QC", "QC" },
                    { 7L, null, "QA", "QA" },
                    { 9L, null, "Finance", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "CheckWithTasks", "CreatedById", "CreatedDate", "ModifiedById", "ModifiedDate", "NextTaskIds", "OrderId", "PrevTaskIds", "ReadOnlyControls", "RequiredControls", "RoleId", "Status", "TaskEnumId", "TaskType", "Title" },
                values: new object[,]
                {
                    { 5, "4", null, null, null, null, "6", 5, "3", "9", "", 3L, 1, 5, 1, "Production Approval" },
                    { 7, "8", null, null, null, null, "9", 7, "", "", "1,2,3,4,5,6,7", 3L, 1, 7, 2, "Project Initiation" },
                    { 10, "11", null, null, null, null, "12", 10, "", "", "11,14,15,16,17,18,19,20", 3L, 1, 10, 2, "Production" },
                    { 4, "5", null, null, null, null, "6", 4, "3", "9", "", 4L, 1, 4, 1, "Design Approval" },
                    { 8, "7", null, null, null, null, "7", 8, "", "", "", 5L, 1, 8, 2, "Repository" },
                    { 11, "10", null, null, null, null, "12", 11, "", "9", "", 5L, 1, 11, 2, "Repository" },
                    { 12, null, null, null, null, null, "13", 2, "", "4", "", 6L, 1, 12, 2, "QC" },
                    { 1, null, null, null, null, null, "2", 1, "", "", "10", 8L, 1, 1, 2, "Financial Proposal" },
                    { 2, null, null, null, null, null, "3", 2, "", "10", "13", 8L, 1, 1, 2, "Confirmation from Sales Team for Client Approval" },
                    { 3, null, null, null, null, null, "4,5", 3, "", "", "9", 8L, 1, 3, 2, "Technical Proposal" },
                    { 6, null, null, null, null, null, "7", 6, "", "9", "", 8L, 1, 6, 2, "Confirmation from Sales Team for Client Approval" },
                    { 9, null, null, null, null, null, "10", 9, "7", "10", "", 9L, 1, 9, 1, "Finance Team Approval" },
                    { 13, null, null, null, null, null, "", 13, "12", "9", "", 9L, 1, 13, 5, "Finance" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1L, 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9L);
        }
    }
}
