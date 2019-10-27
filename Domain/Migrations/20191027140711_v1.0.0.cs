using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerInfos_ExamInfos_ExamInfoID",
                table: "AnswerInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerInfos_Students_StudentInfoID",
                table: "AnswerInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeachers_ClassInfos_ClassInfoID",
                table: "ClassTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeachers_Teachers_TeacherInfoID",
                table: "ClassTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionInfos_ExamInfos_ExamInfoID",
                table: "QuestionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_ExamInfos_ExamInfoID",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ClassExams");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ExamInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionInfos",
                table: "QuestionInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassInfos",
                table: "ClassInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerInfos",
                table: "AnswerInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "QuestionInfos",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "ClassInfos",
                newName: "Classes");

            migrationBuilder.RenameTable(
                name: "AnswerInfos",
                newName: "Answers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "UserBases");

            migrationBuilder.RenameColumn(
                name: "TeacherInfoID",
                table: "ClassTeachers",
                newName: "TeacherInfomationID");

            migrationBuilder.RenameColumn(
                name: "ClassInfoID",
                table: "ClassTeachers",
                newName: "ClassInfomationID");

            migrationBuilder.RenameIndex(
                name: "IX_ClassTeachers_TeacherInfoID",
                table: "ClassTeachers",
                newName: "IX_ClassTeachers_TeacherInfomationID");

            migrationBuilder.RenameIndex(
                name: "IX_ClassTeachers_ClassInfoID",
                table: "ClassTeachers",
                newName: "IX_ClassTeachers_ClassInfomationID");

            migrationBuilder.RenameColumn(
                name: "ExamInfoID",
                table: "Questions",
                newName: "ExamInfomationID");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionInfos_ExamInfoID",
                table: "Questions",
                newName: "IX_Questions_ExamInfomationID");

            migrationBuilder.RenameColumn(
                name: "StudentInfoID",
                table: "Answers",
                newName: "StudentInfomationID");

            migrationBuilder.RenameColumn(
                name: "ExamInfoID",
                table: "Answers",
                newName: "ExamInfomationID");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerInfos_StudentInfoID",
                table: "Answers",
                newName: "IX_Answers_StudentInfomationID");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerInfos_ExamInfoID",
                table: "Answers",
                newName: "IX_Answers_ExamInfomationID");

            migrationBuilder.RenameColumn(
                name: "ExamInfoID",
                table: "UserBases",
                newName: "ExaminationInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_ExamInfoID",
                table: "UserBases",
                newName: "IX_UserBases_ExaminationInfoID");

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                table: "UserBases",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Pwd",
                table: "UserBases",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Profssion",
                table: "UserBases",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserBases",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "Course",
                table: "UserBases",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserBases",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassInfomationID",
                table: "UserBases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "UserBases",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dormitory",
                table: "UserBases",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityNo",
                table: "UserBases",
                maxLength: 18,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParentTel",
                table: "UserBases",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentNo",
                table: "UserBases",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "UserBases",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBases",
                table: "UserBases",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    MenuType = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Url = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClassExaminations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(nullable: true),
                    ClassInfomationID = table.Column<int>(nullable: true),
                    ExamInfomationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassExaminations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClassExaminations_Classes_ClassInfomationID",
                        column: x => x.ClassInfomationID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassExaminations_Examinations_ExamInfomationID",
                        column: x => x.ExamInfomationID,
                        principalTable: "Examinations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(nullable: true),
                    RoleInfomationID = table.Column<int>(nullable: true),
                    MenuInfomationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleMenus_Menus_MenuInfomationID",
                        column: x => x.MenuInfomationID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleMenus_Roles_RoleInfomationID",
                        column: x => x.RoleInfomationID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(nullable: true),
                    UserInfomationID = table.Column<int>(nullable: true),
                    RoleInfomationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleInfomationID",
                        column: x => x.RoleInfomationID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_UserBases_UserInfomationID",
                        column: x => x.UserInfomationID,
                        principalTable: "UserBases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBases_ClassInfomationID",
                table: "UserBases",
                column: "ClassInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExaminations_ClassInfomationID",
                table: "ClassExaminations",
                column: "ClassInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExaminations_ExamInfomationID",
                table: "ClassExaminations",
                column: "ExamInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_MenuInfomationID",
                table: "RoleMenus",
                column: "MenuInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_RoleInfomationID",
                table: "RoleMenus",
                column: "RoleInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleInfomationID",
                table: "UserRoles",
                column: "RoleInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserInfomationID",
                table: "UserRoles",
                column: "UserInfomationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Examinations_ExamInfomationID",
                table: "Answers",
                column: "ExamInfomationID",
                principalTable: "Examinations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_UserBases_StudentInfomationID",
                table: "Answers",
                column: "StudentInfomationID",
                principalTable: "UserBases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeachers_Classes_ClassInfomationID",
                table: "ClassTeachers",
                column: "ClassInfomationID",
                principalTable: "Classes",
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
                name: "FK_Questions_Examinations_ExamInfomationID",
                table: "Questions",
                column: "ExamInfomationID",
                principalTable: "Examinations",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Examinations_ExamInfomationID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_UserBases_StudentInfomationID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeachers_Classes_ClassInfomationID",
                table: "ClassTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassTeachers_UserBases_TeacherInfomationID",
                table: "ClassTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Examinations_ExamInfomationID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBases_Classes_ClassInfomationID",
                table: "UserBases");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBases_Examinations_ExaminationInfoID",
                table: "UserBases");

            migrationBuilder.DropTable(
                name: "ClassExaminations");

            migrationBuilder.DropTable(
                name: "RoleMenus");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBases",
                table: "UserBases");

            migrationBuilder.DropIndex(
                name: "IX_UserBases_ClassInfomationID",
                table: "UserBases");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserBases");

            migrationBuilder.DropColumn(
                name: "ClassInfomationID",
                table: "UserBases");

            migrationBuilder.DropColumn(
                name: "District",
                table: "UserBases");

            migrationBuilder.DropColumn(
                name: "Dormitory",
                table: "UserBases");

            migrationBuilder.DropColumn(
                name: "IdentityNo",
                table: "UserBases");

            migrationBuilder.DropColumn(
                name: "ParentTel",
                table: "UserBases");

            migrationBuilder.DropColumn(
                name: "StudentNo",
                table: "UserBases");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "UserBases");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "QuestionInfos");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "ClassInfos");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "AnswerInfos");

            migrationBuilder.RenameTable(
                name: "UserBases",
                newName: "Teachers");

            migrationBuilder.RenameColumn(
                name: "TeacherInfomationID",
                table: "ClassTeachers",
                newName: "TeacherInfoID");

            migrationBuilder.RenameColumn(
                name: "ClassInfomationID",
                table: "ClassTeachers",
                newName: "ClassInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_ClassTeachers_TeacherInfomationID",
                table: "ClassTeachers",
                newName: "IX_ClassTeachers_TeacherInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_ClassTeachers_ClassInfomationID",
                table: "ClassTeachers",
                newName: "IX_ClassTeachers_ClassInfoID");

            migrationBuilder.RenameColumn(
                name: "ExamInfomationID",
                table: "QuestionInfos",
                newName: "ExamInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ExamInfomationID",
                table: "QuestionInfos",
                newName: "IX_QuestionInfos_ExamInfoID");

            migrationBuilder.RenameColumn(
                name: "StudentInfomationID",
                table: "AnswerInfos",
                newName: "StudentInfoID");

            migrationBuilder.RenameColumn(
                name: "ExamInfomationID",
                table: "AnswerInfos",
                newName: "ExamInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_StudentInfomationID",
                table: "AnswerInfos",
                newName: "IX_AnswerInfos_StudentInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_ExamInfomationID",
                table: "AnswerInfos",
                newName: "IX_AnswerInfos_ExamInfoID");

            migrationBuilder.RenameColumn(
                name: "ExaminationInfoID",
                table: "Teachers",
                newName: "ExamInfoID");

            migrationBuilder.RenameIndex(
                name: "IX_UserBases_ExaminationInfoID",
                table: "Teachers",
                newName: "IX_Teachers_ExamInfoID");

            migrationBuilder.AlterColumn<string>(
                name: "Tel",
                table: "Teachers",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Pwd",
                table: "Teachers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teachers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Profssion",
                table: "Teachers",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Course",
                table: "Teachers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionInfos",
                table: "QuestionInfos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassInfos",
                table: "ClassInfos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerInfos",
                table: "AnswerInfos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Pwd = table.Column<string>(maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    Tel = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExamInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    ClassInfoID = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    District = table.Column<string>(maxLength: 30, nullable: false),
                    Dormitory = table.Column<string>(maxLength: 20, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IdentityNo = table.Column<string>(maxLength: 18, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    ParentTel = table.Column<string>(maxLength: 15, nullable: false),
                    Pwd = table.Column<string>(maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    StudentNo = table.Column<string>(maxLength: 20, nullable: false),
                    Tel = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_ClassInfos_ClassInfoID",
                        column: x => x.ClassInfoID,
                        principalTable: "ClassInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassExams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassInfoID = table.Column<int>(nullable: true),
                    ExamInfoID = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassExams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClassExams_ClassInfos_ClassInfoID",
                        column: x => x.ClassInfoID,
                        principalTable: "ClassInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassExams_ExamInfos_ExamInfoID",
                        column: x => x.ExamInfoID,
                        principalTable: "ExamInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassExams_ClassInfoID",
                table: "ClassExams",
                column: "ClassInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExams_ExamInfoID",
                table: "ClassExams",
                column: "ExamInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassInfoID",
                table: "Students",
                column: "ClassInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerInfos_ExamInfos_ExamInfoID",
                table: "AnswerInfos",
                column: "ExamInfoID",
                principalTable: "ExamInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerInfos_Students_StudentInfoID",
                table: "AnswerInfos",
                column: "StudentInfoID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeachers_ClassInfos_ClassInfoID",
                table: "ClassTeachers",
                column: "ClassInfoID",
                principalTable: "ClassInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassTeachers_Teachers_TeacherInfoID",
                table: "ClassTeachers",
                column: "TeacherInfoID",
                principalTable: "Teachers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionInfos_ExamInfos_ExamInfoID",
                table: "QuestionInfos",
                column: "ExamInfoID",
                principalTable: "ExamInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_ExamInfos_ExamInfoID",
                table: "Teachers",
                column: "ExamInfoID",
                principalTable: "ExamInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
