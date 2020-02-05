using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Entities.ClassAgg;
using Domain.Entities.MenuAgg;
using Domain.Entities.RoleAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Infrastructure.Utils;

namespace Infrastructure.EfCore
{
    public class SeedData
    {
        private readonly IExamDbContext context;

        public SeedData(IExamDbContext cxt)
        {
            this.context = cxt;
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <param name="context">数据上下文</param>
        public void InitializeMenus()
        {
            if (context.Menus.Any())
                return;
            var lstMenus = new List<MenuInfo>
            {
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.菜单, Title="首页", Controller="Home", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.模块, Title="系统管理", Controller="System", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.模块, Title="班级管理", Controller="Class", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.模块, Title="教师管理", Controller="Teacher", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.模块, Title="学生管理", Controller="Student", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.模块, Title="考试管理", Controller="Examination", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.模块, Title="试卷管理", Controller="Answer", Action="Index" },
                new MenuInfo{ Remarks="暂无", ParentId=0, MenuType=CommType.模块, Title="题库管理", Controller="Question", Action="Index" }
            };
            foreach (var menu in lstMenus)
            {
                context.Menus.Add(menu);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// 初始化角色
        /// </summary>
        /// <param name="context">数据上下文</param>
        public void InitializeRoles()
        {
            if (context.Roles.Any())
                return;
            context.Roles.Add(ApplicationFactory.Create<RoleInfo>(func: r =>
            {
                r.Name = "管理员";
                r.Code = "admin";
                r.Remarks = "暂无";
                return r;
            }));
            context.Roles.Add(ApplicationFactory.Create<RoleInfo>(func: r =>
            {
                r.Name = "教师";
                r.Code = "teacher";
                r.Remarks = "暂无";
                return r;
            }));
            context.Roles.Add(ApplicationFactory.Create<RoleInfo>(func: r =>
            {
                r.Name = "学生";
                r.Code = "student";
                r.Remarks = "暂无";
                return r;
            }));
            context.SaveChanges();
        }

        /// <summary>
        /// 初始化角色菜单
        /// </summary>
        /// <param name="context">数据上下文</param>
        public void InitializeRoleMenus()
        {
            if (context.RoleMenus.Any())
                return;
            var roleMenus = new List<RoleMenu>
            {
                #region admin
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=1;
                    e.MenuInfomation.ID=1;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=1;
                    e.MenuInfomation.ID=2;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=1;
                    e.MenuInfomation.ID=3;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=1;
                    e.MenuInfomation.ID=4;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=1;
                    e.MenuInfomation.ID=5;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=1;
                    e.MenuInfomation.ID=6;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=1;
                    e.MenuInfomation.ID=7;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=1;
                    e.MenuInfomation.ID=8;
                    return e;
                }),
                #endregion
                #region teacher
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=2;
                    e.MenuInfomation.ID=1;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=2;
                    e.MenuInfomation.ID=3;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=2;
                    e.MenuInfomation.ID=5;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=2;
                    e.MenuInfomation.ID=6;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=2;
                    e.MenuInfomation.ID=7;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=2;
                    e.MenuInfomation.ID=8;
                    return e;
                }),
                #endregion
                #region student
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=3;
                    e.MenuInfomation.ID=1;
                    return e;
                }),
                ApplicationFactory.Create<RoleMenu>(func:e=>{
                    e.RoleInfomation.ID=3;
                    e.MenuInfomation.ID=6;
                    return e;
                })
	            #endregion
            };
            foreach (var menu in roleMenus)
            {
                context.RoleMenus.Add(menu);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// 初始化班级数据
        /// </summary>
        /// <param name="context">数据上下文</param>
        public void InitializeClasses()
        {
            if (context.Classes.Any())
                return;
            context.Classes.Add(ApplicationFactory.Create<ClassInfo>(func: cls =>
            {
                cls.Remarks = "暂无";
                cls.Name = "1701";
                cls.Grade = ClassGrade.三年级;
                cls.Category = CommType.高考班;
                cls.CreateDate = DateTime.Now;
                cls.Status = ClassStatus.未启用;
                return cls;
            }));
            context.SaveChanges();
        }

        /// <summary>
        /// 初始化用户
        /// </summary>
        /// <param name="context">数据上下文</param>
        public void InitializeUsers()
        {
            if (context.Admins.Any())
                return;
            //初始化管理员数据
            context.Admins.Add(ApplicationFactory.Create<AdminInfo>(func: adm =>
            {
                adm.Remarks = "系统管理员";
                adm.Account = "sysadmin";
                adm.Pwd = "a1234567";
                adm.Gender = Gender.男;
                adm.Age = 38;
                adm.Tel = "18673968186";
                adm.CreateDate = DateTime.Now;
                return adm;
            }));
            //初始化教师数据
            context.Teachers.Add(ApplicationFactory.Create<TeacherInfo>(func: thr =>
            {
                thr.Remarks = "C语言教师";
                thr.Account = "teacher1";
                thr.Pwd = "a1234567";
                thr.Gender = Gender.男;
                thr.Age = 38;
                thr.Tel = "18673968186";
                thr.CreateDate = DateTime.Now;
                thr.Profssion = "软件工程";
                thr.Course = CommType.C语言;
                return thr;
            }));
            //初始化学生数据
            context.Students.Add(ApplicationFactory.Create<StudentInfo>(func: stu =>
            {
                stu.Remarks = "学生";
                stu.Account = "student1";
                stu.Pwd = "a1234567";
                stu.Gender = Gender.男;
                stu.Age = 16;
                stu.Tel = "18673968186";
                stu.CreateDate = DateTime.Now;
                stu.StudentNo = "170101";
                stu.IdentityNo = "430503031015907687";
                stu.ParentTel = "13907390000";
                stu.District = "大祥区";
                stu.Address = "电大路2号医药局2栋3单元502";
                stu.Dormitory = "02001";
                stu.ClassInfomation = ApplicationFactory.Create<ClassInfo>(func: cls => { cls.ID = 1; return cls; });
                return stu;
            }));
            context.SaveChanges();
        }
    }
}
