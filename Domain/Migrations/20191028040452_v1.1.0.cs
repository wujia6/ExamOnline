using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class v110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Examinations_ExamInfomationID",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Users",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "ExamInfomationID",
                table: "Questions",
                newName: "ExaminationInfomationID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ExamInfomationID",
                table: "Questions",
                newName: "IX_Questions_ExaminationInfomationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Examinations_ExaminationInfomationID",
                table: "Questions",
                column: "ExaminationInfomationID",
                principalTable: "Examinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Examinations_ExaminationInfomationID",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "Users",
                newName: "Discriminator");

            migrationBuilder.RenameColumn(
                name: "ExaminationInfomationID",
                table: "Questions",
                newName: "ExamInfomationID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ExaminationInfomationID",
                table: "Questions",
                newName: "IX_Questions_ExamInfomationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Examinations_ExamInfomationID",
                table: "Questions",
                column: "ExamInfomationID",
                principalTable: "Examinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
