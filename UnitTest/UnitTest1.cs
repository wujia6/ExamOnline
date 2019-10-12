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
                    Gender.ÄÐ,
                    38,
                    "18673968186",
                    DateTime.Now,
                    "ÔÝÎÞ"
                });
            Type t = userInfo.GetType();
            string typeName = t.Name;
            Console.WriteLine(userInfo.Pwd);
            Console.WriteLine(typeName);
        }
    }
}
