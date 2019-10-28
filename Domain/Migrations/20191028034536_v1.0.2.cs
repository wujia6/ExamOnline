using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class v102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_UserBases_StudentInfomationID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeachers_UserBases_TeacherInfomationID",
                table: "ClassTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBases_Classes_ClassInfomationID",
                table: "UserBases");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBases_Examinations_ExaminationInfoID",
                table: "UserBases");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_UserBases_UserInfomationID",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBases",
                table: "UserBases");

            migrationBuilder.RenameTable(
                name: "UserBases",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UserBases_ExaminationInfoID",
                table: "Users",
                newName: "IX_Users_ExaminationInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_UserBases_ClassInfomationID",
                table: "Users",
                newName: "IX_Users_ClassInfomationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_StudentInfomationID",
                table: "Answers",
                column: "StudentInfomationID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeachers_Users_TeacherInfomationID",
                table: "ClassTeachers",
                column: "TeacherInfomationID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserInfomationID",
                table: "UserRoles",
                column: "UserInfomationID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Classes_ClassInfomationID",
                table: "Users",
                column: "ClassInfomationID",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Examinations_ExaminationInfoID",
                table: "Users",
                column: "ExaminationInfoID",
                principalTable: "Examinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_StudentInfomationID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeachers_Users_TeacherInfomationID",
                table: "ClassTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserInfomationID",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classes_ClassInfomationID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Examinations_ExaminationInfoID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserBases");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ExaminationInfoID",
                table: "UserBases",
                newName: "IX_UserBases_ExaminationInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ClassInfomationID",
                table: "UserBases",
                newName: "IX_UserBases_ClassInfomationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBases",
                table: "UserBases",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_UserBases_StudentInfomationID",
                table: "Answers",
                column: "StudentInfomationID",
                principalTable: "UserBases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeachers_UserBases_TeacherInfomationID",
                table: "ClassTeachers",
                column: "TeacherInfomationID",
                principalTable: "UserBases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBases_Classes_ClassInfomationID",
                table: "UserBases",
                column: "ClassInfomationID",
                principalTable: "Classes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBases_Examinations_ExaminationInfoID",
                table: "UserBases",
                column: "ExaminationInfoID",
                principalTable: "Examinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_UserBases_UserInfomationID",
                table: "UserRoles",
                column: "UserInfomationID",
                principalTable: "UserBases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
