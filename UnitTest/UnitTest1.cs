using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Entities.UserAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.AnwserAgg;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var userInfo = EntityFactory.CreateInstance<Admin>(new object[]{
                new Guid(),
                "administrator",
                "password",
                "wujia",
                Gender.男,
                38,
                "18673968186",
                DateTime.Now,
                "暂无"
            });
            string typeName = userInfo.GetType().Name;
        }

        [TestMethod]
        public void TestClassInfo()
        {
            var classInfo=EntityFactory.CreateInstance<ClassInfo>();
            var classEntity=EntityFactory.CreateInstance<ClassInfo>(new object[]{
                new Guid(),
                "1701",
                ClassGrade.三年级,
                ClassCategory.高考班,
                DateTime.Now,
                ClassStatus.未启用,
                "暂无"
            });

            if (classInfo == null)
                classInfo = null;
            else if (classEntity == null)
                classEntity = null;
        }
    }
}
