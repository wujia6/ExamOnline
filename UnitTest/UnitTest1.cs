using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Entities.UserAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.AnwserAgg;
using Infrastructure.Utils;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserAggTest()
        {
            var admin = EntityFactory.CreateInstance<AdminInfo>(new object[] {
                1,
                "administrator",
                "password",
                "wujia",
                Gender.男,
                38,
                "18673968186",
                DateTime.Now,
                "暂无"
            });

            var teacher = EntityFactory.CreateInstance<TeacherInfo>(new object[] {
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

            var student = EntityFactory.CreateInstance<StudentInfo>(new object[] {
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
        }

        [TestMethod]
        public void ClassAggTest()
        {
            //var classInfo=EntityFactory.CreateInstance<ClassInfo>();
            var classEntity=EntityFactory.CreateInstance<ClassInfo>(new object[]{
                1,
                "1701",
                ClassGrade.三年级,
                CommType.高考班,
                DateTime.Now,
                ClassStatus.未启用,
                "暂无"
            });
        }

        [TestMethod]
        public void ConnectionStringsTest()
        {
            string connString = ConfigurationUtils.GetSection("ConnectionStrings");
        }
    }
}
