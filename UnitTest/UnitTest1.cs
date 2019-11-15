using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Entities.UserAgg;
using Domain.Entities.QuestionAgg;
using Domain.Entities.ExamAgg;
using Domain.Entities.ClassAgg;
using Domain.Entities.AnwserAgg;
using Infrastructure.Utils;
using Application.DTO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserAggTest()
        {
            AutoMapperHelper.SetMappings();
            var classInfo = EntityFactory.Create<ClassInfo>(new object[]{
                "1701",
                ClassGrade.三年级,
                CommType.高考班,
                DateTime.Now,
                ClassStatus.未启用,
                1,
                "暂无"
            });
            var adminInfo = EntityFactory.Create<AdminInfo>(new object[] {
                "administrator",
                "password",
                "wujia",
                Gender.男,
                38,
                "18673968186",
                DateTime.Now,
                1,
                "暂无"
            });
            var adminDto = adminInfo.MapTo<AdminDTO>();
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
            teacherInfo.ClassTeachers = new List<ClassTeacher>
            {
                new ClassTeacher()
                {
                    ID = 1,
                    Remarks = "暂无"
                }
            }.AsQueryable();
            var teacherDto = teacherInfo.MapTo<TeacherDTO>();
            var student = EntityFactory.Create<StudentInfo>(new object[] {
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
            var classEntity=EntityFactory.Create<ClassInfo>(new object[]{
                "1701",
                ClassGrade.三年级,
                CommType.高考班,
                DateTime.Now,
                ClassStatus.未启用,
                1,
                "暂无"
            });
            var clsDto = Mapper.Map<ClassInfo, ClassDTO>(classEntity);
        }

        [TestMethod]
        public void ConnectionStringsTest()
        {
            //string connString = ConfigUtils.GetConfig("ConnectionStrings:ExamDbConn");
        }

        [TestMethod]
        public void GetClassInstanceTest()
        {
            //var classInstance = Assembly.LoadFrom("Application.dll").CreateInstance("Application.DTO.RuleConfig");
            //classInstance.GetType().GetMethod("Initialize").Invoke(classInstance, null);
            //AutoMapperHelper.SetMappings();
        }
    }
}
