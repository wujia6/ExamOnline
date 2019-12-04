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
using Application.DTO.Mappings;
using Application.DTO;
using Domain.Entities.RoleAgg;
using Infrastructure.EfCore;
using Domain.IComm;
using Microsoft.EntityFrameworkCore;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserAggTest()
        {
            AutoMapperHelper.SetMappings();
            var userInfo = EntityFactory.Create<AdminInfo>(usr =>
            {
                usr.ID = 1;
                usr.Remarks = "暂无";
                usr.Account = "sysadmin";
                usr.Pwd = "a1234567";
                usr.Name = "wujia";
                usr.Gender = 0;
                usr.Age = 38;
                usr.Tel = "18673968186";
                usr.CreateDate = DateTime.Now;
                usr.UserRoles = new List<UserRole>
                {
                    new UserRole{ ID=1, Remarks="暂无", RoleInfomation=EntityFactory.Create<RoleInfo>(r=>
                    {
                        r.ID=1;
                        r.Name="管理员";
                        r.Code="admin";
                        r.Remarks="暂无";
                        return r;
                    }), UserInfomation = null }
                };
                return usr;
            });
            var userDto = userInfo.MapTo<UserDTO>();
            //var classInfo = EntityFactory.Create<ClassInfo>(new object[]{
            //    "1701",
            //    ClassGrade.三年级,
            //    CommType.高考班,
            //    DateTime.Now,
            //    ClassStatus.未启用,
            //    1,
            //    "暂无"
            //});
            //var teacherInfo = EntityFactory.Create<TeacherInfo>(new object[] {
            //    "软件工程",
            //    CommType.C语言,
            //    "Teacher01",
            //    "password",
            //    "吴嘉",
            //    Gender.男,
            //    35,
            //    "16673956869",
            //    DateTime.Now,
            //    1,
            //    "暂无"
            //});
            //teacherInfo.ClassTeachers = new List<ClassTeacher>
            //{
            //    new ClassTeacher()
            //    {
            //        ID = 1,
            //        Remarks = "暂无"
            //    }
            //}.AsQueryable();
            //var teacherDto = teacherInfo.MapTo<TeacherDTO>();
            //var student = EntityFactory.Create<StudentInfo>(new object[] {
            //    "170101",
            //    "430503190102163958",
            //    "13907390101",
            //    "大祥区",
            //    "西湖路滑石新村",
            //    "1101",
            //    "Student01",
            //    "passsword",
            //    "学生01",
            //    Gender.男,
            //    18,
            //    "13907390001",
            //    DateTime.Now,
            //    1001,
            //    "暂无"
            //});
        }
    }
}
