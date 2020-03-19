﻿// <auto-generated />
using System;
using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ExamDbContext))]
    [Migration("20200222114607_v2.3")]
    partial class v23
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.AnwserAgg.AnswerInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExamInfomationID");

                    b.Property<string>("Remarks");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Score");

                    b.Property<int?>("StudentInfomationID");

                    b.HasKey("ID");

                    b.HasIndex("ExamInfomationID");

                    b.HasIndex("StudentInfomationID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Domain.Entities.ClassAgg.ClassExamination", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassInfomationID");

                    b.Property<int?>("ExamInfomationID");

                    b.Property<string>("Remarks");

                    b.HasKey("ID");

                    b.HasIndex("ClassInfomationID");

                    b.HasIndex("ExamInfomationID");

                    b.ToTable("ClassExaminations");
                });

            modelBuilder.Entity("Domain.Entities.ClassAgg.ClassInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("Grade");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Domain.Entities.ClassAgg.ClassTeacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassInfomationID");

                    b.Property<string>("Remarks");

                    b.Property<int?>("TeacherInfomationID");

                    b.HasKey("ID");

                    b.HasIndex("ClassInfomationID");

                    b.HasIndex("TeacherInfomationID");

                    b.ToTable("ClassTeachers");
                });

            modelBuilder.Entity("Domain.Entities.ExamAgg.ExaminationInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginTime");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Remarks")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Examinations");
                });

            modelBuilder.Entity("Domain.Entities.MenuAgg.MenuInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Controller")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("MenuType");

                    b.Property<int>("ParentId");

                    b.Property<string>("Remarks")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Domain.Entities.PermissionAgg.PermissionInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Command")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("LevelID");

                    b.Property<string>("Named")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Remarks")
                        .HasMaxLength(50);

                    b.Property<int>("TypeAt");

                    b.HasKey("ID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Domain.Entities.QuestionAgg.QuestionInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<int>("Category");

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("ExaminationInfomationID");

                    b.Property<int>("Level");

                    b.Property<string>("Remarks")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("ExaminationInfomationID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Domain.Entities.RoleAgg.RoleAuthorize", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PermissionInformationID");

                    b.Property<string>("Remarks")
                        .HasMaxLength(50);

                    b.Property<int?>("RoleInformationID");

                    b.HasKey("ID");

                    b.HasIndex("PermissionInformationID");

                    b.HasIndex("RoleInformationID");

                    b.ToTable("RoleAuthorizes");
                });

            modelBuilder.Entity("Domain.Entities.RoleAgg.RoleInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Remarks")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entities.RoleAgg.RoleMenu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MenuInfomationID");

                    b.Property<string>("Remarks")
                        .HasMaxLength(50);

                    b.Property<int?>("RoleInfomationID");

                    b.HasKey("ID");

                    b.HasIndex("MenuInfomationID");

                    b.HasIndex("RoleInfomationID");

                    b.ToTable("RoleMenus");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.UserInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Age");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int>("Gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Remarks")
                        .HasMaxLength(50);

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("UserType")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("UserInfo");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.UserRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Remarks")
                        .HasMaxLength(50);

                    b.Property<int?>("RoleInfomationID");

                    b.Property<int?>("UserInfomationID");

                    b.HasKey("ID");

                    b.HasIndex("RoleInfomationID");

                    b.HasIndex("UserInfomationID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.AdminInfo", b =>
                {
                    b.HasBaseType("Domain.Entities.UserAgg.UserInfo");

                    b.HasDiscriminator().HasValue("admin");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.StudentInfo", b =>
                {
                    b.HasBaseType("Domain.Entities.UserAgg.UserInfo");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ClassInfomationID");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Dormitory")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("IdentityNo")
                        .IsRequired()
                        .HasMaxLength(18);

                    b.Property<string>("ParentTel")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("StudentNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasIndex("ClassInfomationID");

                    b.HasDiscriminator().HasValue("student");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.TeacherInfo", b =>
                {
                    b.HasBaseType("Domain.Entities.UserAgg.UserInfo");

                    b.Property<int>("Course");

                    b.Property<int?>("ExaminationInfoID");

                    b.Property<string>("Profssion")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasIndex("ExaminationInfoID");

                    b.HasDiscriminator().HasValue("teacher");
                });

            modelBuilder.Entity("Domain.Entities.AnwserAgg.AnswerInfo", b =>
                {
                    b.HasOne("Domain.Entities.ExamAgg.ExaminationInfo", "ExamInfomation")
                        .WithMany("AnswerInfomations")
                        .HasForeignKey("ExamInfomationID");

                    b.HasOne("Domain.Entities.UserAgg.StudentInfo", "StudentInfomation")
                        .WithMany("AnswerInfomations")
                        .HasForeignKey("StudentInfomationID");
                });

            modelBuilder.Entity("Domain.Entities.ClassAgg.ClassExamination", b =>
                {
                    b.HasOne("Domain.Entities.ClassAgg.ClassInfo", "ClassInfomation")
                        .WithMany("ClassExams")
                        .HasForeignKey("ClassInfomationID");

                    b.HasOne("Domain.Entities.ExamAgg.ExaminationInfo", "ExamInfomation")
                        .WithMany("ClassExams")
                        .HasForeignKey("ExamInfomationID");
                });

            modelBuilder.Entity("Domain.Entities.ClassAgg.ClassTeacher", b =>
                {
                    b.HasOne("Domain.Entities.ClassAgg.ClassInfo", "ClassInfomation")
                        .WithMany("ClassTeachers")
                        .HasForeignKey("ClassInfomationID");

                    b.HasOne("Domain.Entities.UserAgg.TeacherInfo", "TeacherInfomation")
                        .WithMany("ClassTeachers")
                        .HasForeignKey("TeacherInfomationID");
                });

            modelBuilder.Entity("Domain.Entities.QuestionAgg.QuestionInfo", b =>
                {
                    b.HasOne("Domain.Entities.ExamAgg.ExaminationInfo", "ExaminationInfomation")
                        .WithMany("QuestionInfomations")
                        .HasForeignKey("ExaminationInfomationID");
                });

            modelBuilder.Entity("Domain.Entities.RoleAgg.RoleAuthorize", b =>
                {
                    b.HasOne("Domain.Entities.PermissionAgg.PermissionInfo", "PermissionInformation")
                        .WithMany("RoleAuthorizes")
                        .HasForeignKey("PermissionInformationID");

                    b.HasOne("Domain.Entities.RoleAgg.RoleInfo", "RoleInformation")
                        .WithMany("RoleAuthorizes")
                        .HasForeignKey("RoleInformationID");
                });

            modelBuilder.Entity("Domain.Entities.RoleAgg.RoleMenu", b =>
                {
                    b.HasOne("Domain.Entities.MenuAgg.MenuInfo", "MenuInfomation")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuInfomationID");

                    b.HasOne("Domain.Entities.RoleAgg.RoleInfo", "RoleInfomation")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleInfomationID");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.RoleAgg.RoleInfo", "RoleInfomation")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleInfomationID");

                    b.HasOne("Domain.Entities.UserAgg.UserInfo", "UserInfomation")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserInfomationID");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.StudentInfo", b =>
                {
                    b.HasOne("Domain.Entities.ClassAgg.ClassInfo", "ClassInfomation")
                        .WithMany("StudentInfomations")
                        .HasForeignKey("ClassInfomationID");
                });

            modelBuilder.Entity("Domain.Entities.UserAgg.TeacherInfo", b =>
                {
                    b.HasOne("Domain.Entities.ExamAgg.ExaminationInfo")
                        .WithMany("TeacherInfomations")
                        .HasForeignKey("ExaminationInfoID");
                });
#pragma warning restore 612, 618
        }
    }
}