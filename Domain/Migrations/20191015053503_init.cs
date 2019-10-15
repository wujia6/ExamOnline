using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Pwd = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(maxLength: 15, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClassInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExamInfos",
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
                    table.PrimaryKey("PK_ExamInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Pwd = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(maxLength: 15, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    StudentNo = table.Column<string>(maxLength: 20, nullable: false),
                    IdentityNo = table.Column<string>(maxLength: 18, nullable: false),
                    ParentTel = table.Column<string>(maxLength: 15, nullable: false),
                    District = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Dormitory = table.Column<string>(maxLength: 20, nullable: false),
                    ClassInfoID = table.Column<int>(nullable: true)
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
                    Remarks = table.Column<string>(nullable: true),
                    ClassInfoID = table.Column<int>(nullable: true),
                    ExamInfoID = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "QuestionInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Contents = table.Column<string>(maxLength: 200, nullable: false),
                    Answer = table.Column<string>(nullable: false),
                    ExamInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuestionInfos_ExamInfos_ExamInfoID",
                        column: x => x.ExamInfoID,
                        principalTable: "ExamInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Pwd = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(maxLength: 15, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Profssion = table.Column<string>(maxLength: 20, nullable: false),
                    Course = table.Column<int>(nullable: false),
                    ExamInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teachers_ExamInfos_ExamInfoID",
                        column: x => x.ExamInfoID,
                        principalTable: "ExamInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerInfos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(nullable: true),
                    Result = table.Column<string>(maxLength: 200, nullable: false),
                    Score = table.Column<int>(nullable: false),
                    ExamInfoID = table.Column<int>(nullable: true),
                    StudentInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerInfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnswerInfos_ExamInfos_ExamInfoID",
                        column: x => x.ExamInfoID,
                        principalTable: "ExamInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerInfos_Students_StudentInfoID",
                        column: x => x.StudentInfoID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassTeachers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(nullable: true),
                    ClassInfoID = table.Column<int>(nullable: true),
                    TeacherInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClassTeachers_ClassInfos_ClassInfoID",
                        column: x => x.ClassInfoID,
                        principalTable: "ClassInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTeachers_Teachers_TeacherInfoID",
                        column: x => x.TeacherInfoID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerInfos_ExamInfoID",
                table: "AnswerInfos",
                column: "ExamInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerInfos_StudentInfoID",
                table: "AnswerInfos",
                column: "StudentInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExams_ClassInfoID",
                table: "ClassExams",
                column: "ClassInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExams_ExamInfoID",
                table: "ClassExams",
                column: "ExamInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeachers_ClassInfoID",
                table: "ClassTeachers",
                column: "ClassInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeachers_TeacherInfoID",
                table: "ClassTeachers",
                column: "TeacherInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionInfos_ExamInfoID",
                table: "QuestionInfos",
                column: "ExamInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassInfoID",
                table: "Students",
                column: "ClassInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ExamInfoID",
                table: "Teachers",
                column: "ExamInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AnswerInfos");

            migrationBuilder.DropTable(
                name: "ClassExams");

            migrationBuilder.DropTable(
                name: "ClassTeachers");

            migrationBuilder.DropTable(
                name: "QuestionInfos");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "ClassInfos");

            migrationBuilder.DropTable(
                name: "ExamInfos");
        }
    }
}
