using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Entities.ClassAgg;
using Domain.Entities.MenuAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;

namespace Domain.Profile
{
    public static class DbSeed
    {
        public static void Initialize(IExamDbContext context)
        {
            if (context.Classes.Any())
                return;
            var classInfo = EntityFactory.Create<ClassInfo>(new object[] {
                "1701",
                ClassGrade.三年级,
                CommType.高考班,
                DateTime.Now,
                ClassStatus.未启用,
                1,
                "暂无"
            });
            context.Classes.Add(classInfo);

            if (context.ClassTeachers.Any())
                return;
            var classTeacher = EntityFactory.Create<ClassTeacher>(new object[] { 1, 1, 1, "暂无" });
            context.ClassTeachers.Add(classTeacher);

            if (context.Admins.Any())
                return;
            var adminInfo = EntityFactory.Create<AdminInfo>(new object[] {
                "admin",
                "password",
                "管理员",
                Gender.男,
                38,
                "18673968186",
                DateTime.Now,
                1,
                "暂无"
            });
            context.Admins.Add(adminInfo);

            if (context.Teachers.Any())
                return;
            var teacherInfo = EntityFactory.Create<TeacherInfo>(new object[] {
                "软件工程",
                CommType.C语言,
                "Teacher01",
                "password",
                "吴嘉",
                Gender.男,
                35,
                "16673956869",
                DateTime.Now,
                1,
                "暂无"
            });
            context.Teachers.Add(teacherInfo);

            if (context.Students.Any())
                return;
            var studentInfo = EntityFactory.Create<StudentInfo>(new object[] {
                "170101",
                "430503190102163958",
                "13907390101",
                "大祥区",
                "西湖路滑石新村",
                "1101",
                "Student01",
                "passsword",
                "学生01",
                Gender.男,
                18,
                "13907390001",
                DateTime.Now,
                1001,
                "暂无"
            });
            context.Students.Add(studentInfo);

            context.SaveChanges();
        }

        public static void InitializeMenus(IExamDbContext context)
        {
            if (context.Menus.Any())
                return;
            var lstMenus = new List<MenuInfo>
            {
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.action, Title="首页", Controller="Home", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.action, Title="班级管理", Controller="Class", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.action, Title="教师管理", Controller="Teacher", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.action, Title="学生管理", Controller="Student", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.action, Title="考试管理", Controller="Examination", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.action, Title="试卷管理", Controller="Answer", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.action, Title="题库管理", Controller="Question", Action="Index" }
            };
            foreach (var menu in lstMenus)
            {
                context.Menus.Add(menu);
            }
            context.SaveChanges();
        }
    }
}
