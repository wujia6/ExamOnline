using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
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
                    table.PrimaryKey("PK_Classes", x => x.ID);
                });

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
                    Controller = table.Column<string>(maxLength: 20, nullable: false),
                    Action = table.Column<string>(maxLength: 20, nullable: false)
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
                name: "Questions",
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
                    ExaminationInfomationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Questions_Examinations_ExaminationInfomationID",
                        column: x => x.ExaminationInfomationID,
                        principalTable: "Examinations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Pwd = table.Column<string>(maxLength: 30, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Tel = table.Column<string>(maxLength: 11, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UserType = table.Column<string>(nullable: false),
                    StudentNo = table.Column<string>(maxLength: 20, nullable: true),
                    IdentityNo = table.Column<string>(maxLength: 18, nullable: true),
                    ParentTel = table.Column<string>(maxLength: 15, nullable: true),
                    District = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Dormitory = table.Column<string>(maxLength: 20, nullable: true),
                    ClassInfomationID = table.Column<int>(nullable: true),
                    Profssion = table.Column<string>(maxLength: 20, nullable: true),
                    Course = table.Column<int>(nullable: true),
                    ExaminationInfoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Classes_ClassInfomationID",
                        column: x => x.ClassInfomationID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Examinations_ExaminationInfoID",
                        column: x => x.ExaminationInfoID,
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
                name: "Answers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(nullable: true),
                    Result = table.Column<string>(maxLength: 200, nullable: false),
                    Score = table.Column<int>(nullable: false),
                    ExamInfomationID = table.Column<int>(nullable: true),
                    StudentInfomationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answers_Examinations_ExamInfomationID",
                        column: x => x.ExamInfomationID,
                        principalTable: "Examinations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Users_StudentInfomationID",
                        column: x => x.StudentInfomationID,
                        principalTable: "Users",
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
                    ClassInfomationID = table.Column<int>(nullable: true),
                    TeacherInfomationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClassTeachers_Classes_ClassInfomationID",
                        column: x => x.ClassInfomationID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTeachers_Users_TeacherInfomationID",
                        column: x => x.TeacherInfomationID,
                        principalTable: "Users",
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
                        name: "FK_UserRoles_Users_UserInfomationID",
                        column: x => x.UserInfomationID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ExamInfomationID",
                table: "Answers",
                column: "ExamInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_StudentInfomationID",
                table: "Answers",
                column: "StudentInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExaminations_ClassInfomationID",
                table: "ClassExaminations",
                column: "ClassInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassExaminations_ExamInfomationID",
                table: "ClassExaminations",
                column: "ExamInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeachers_ClassInfomationID",
                table: "ClassTeachers",
                column: "ClassInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeachers_TeacherInfomationID",
                table: "ClassTeachers",
                column: "TeacherInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExaminationInfomationID",
                table: "Questions",
                column: "ExaminationInfomationID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClassInfomationID",
                table: "Users",
                column: "ClassInfomationID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ExaminationInfoID",
                table: "Users",
                column: "ExaminationInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "ClassExaminations");

            migrationBuilder.DropTable(
                name: "ClassTeachers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "RoleMenus");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Examinations");
        }
    }
}
