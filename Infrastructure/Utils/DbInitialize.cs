using System;
using System.Linq;
using Domain.IComm;
using Domain.Entities;
using Domain.Entities.UserAgg;
using Domain.Entities.ClassAgg;

namespace Infrastructure.Utils
{
    public static class DbInitialize
    {
        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="context">上下文接口对象</param>
        public static void Seed(IExamDbContext context)
        {
            if (context.ClassInfos.Any())
                return;
            var classInfo = EntityFactory.CreateInstance<ClassInfo>(new object[] {
                "1701",
                ClassGrade.三年级,
                CommType.高考班,
                DateTime.Now,
                ClassStatus.未启用,
                1,
                "暂无"
            });
            context.ClassInfos.Add(classInfo);

            if (context.ClassTeachers.Any())
                return;
            var classTeacher = EntityFactory.CreateInstance<ClassTeacher>(new object[] { 1, 1, 1, "暂无" });
            context.ClassTeachers.Add(classTeacher);

            if (context.Admins.Any())
                return;
            var adminInfo = EntityFactory.CreateInstance<AdminInfo>(new object[] {
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
            var teacherInfo = EntityFactory.CreateInstance<TeacherInfo>(new object[] {
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
            var studentInfo = EntityFactory.CreateInstance<StudentInfo>(new object[] {
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
    }
}
