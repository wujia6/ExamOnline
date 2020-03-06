using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.MenuAgg;
using Domain.Entities.PermissionAgg;
using Domain.Entities.RoleAgg;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Infrastructure.Utils;
using System.Linq;

namespace Infrastructure.EfCore
{
    public class DbSeed
    {
        /// <summary>
        /// 初始化种子数据
        /// </summary>
        /// <param name="applicationContext">DbContext上下文</param>
        /// <returns></returns>
        public static async Task InitializeAsync(IExamDbContext applicationContext)
        {
            try
            {
                // 初始化权限
                if (!await applicationContext.Permissions.AnyAsync())
                {
                    var lstPerms = new List<PermissionInfo>
                    {
                        //module
                        new PermissionInfo{ Remarks="暂无", LevelID=0, TypeAt=21, Named="系统管理", Command="sys", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=0, TypeAt=21, Named="班级管理", Command="cls", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=0, TypeAt=21, Named="教师管理", Command="thr", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=0, TypeAt=21, Named="学生管理", Command="stu", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=0, TypeAt=21, Named="考试管理", Command="exam", Enabled=true },
                        //module/controllers
                        new PermissionInfo{ Remarks="暂无", LevelID=1, TypeAt=22, Named="站点设置", Command="settings", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=1, TypeAt=22, Named="开发者设置", Command="developer", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=1, TypeAt=22, Named="权限设置", Command="permission", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=1, TypeAt=22, Named="角色设置", Command="role", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=1, TypeAt=22, Named="菜单设置", Command="menu", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=1, TypeAt=22, Named="报表设置", Command="report", Enabled=true },
                        //module/controller/actions
                        new PermissionInfo{ Remarks="暂无", LevelID=6, TypeAt=23, Named="站点设置1", Command="action1", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=6, TypeAt=23, Named="站点设置2", Command="action2", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=7, TypeAt=23, Named="开发者设置1", Command="action1", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=7, TypeAt=23, Named="开发者设置2", Command="action2", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=8, TypeAt=23, Named="编辑", Command="edit", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=8, TypeAt=23, Named="删除", Command="remove", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=8, TypeAt=23, Named="浏览", Command="browse", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=9, TypeAt=23, Named="新增", Command="add", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=9, TypeAt=23, Named="删除", Command="remove", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=9, TypeAt=23, Named="编辑", Command="edit", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=9, TypeAt=23, Named="浏览", Command="browse", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=10, TypeAt=23, Named="新增", Command="add", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=10, TypeAt=23, Named="删除", Command="remove", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=10, TypeAt=23, Named="编辑", Command="edit", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=10, TypeAt=23, Named="浏览", Command="browse", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=11, TypeAt=23, Named="导出", Command="export", Enabled=true },
                        new PermissionInfo{ Remarks="暂无", LevelID=11, TypeAt=23, Named="浏览", Command="browse", Enabled=true },
                    };
                    await applicationContext.Permissions.AddRangeAsync(lstPerms);
                }
                // 初始化角色
                if (!await applicationContext.Roles.AnyAsync())
                {
                    var lstRoles = new List<RoleInfo>
                    {
                        ApplicationFactory.Create<RoleInfo>(func: r =>
                        {
                            r.Name = "管理员";
                            r.Code = "admin";
                            r.Remarks = "暂无";
                            return r;
                        }),
                        ApplicationFactory.Create<RoleInfo>(func: r =>
                        {
                            r.Name = "教师";
                            r.Code = "teacher";
                            r.Remarks = "暂无";
                            return r;
                        }),
                        ApplicationFactory.Create<RoleInfo>(func:r=>
                        {
                            r.Name = "学生";
                            r.Code = "student";
                            r.Remarks = "暂无";
                            return r;
                        })
                    };
                    await applicationContext.Roles.AddRangeAsync(lstRoles);
                }
                // 初始化角色授权
                if (!await applicationContext.RoleAuthorizes.AnyAsync())
                {
                    var lstAuthorizes = new List<RoleAuthorize>();
                    for (int i = 1; i <= 28; i++)
                    {
                        lstAuthorizes.Add(ApplicationFactory.Create<RoleAuthorize>(func: src =>
                        {
                            src.RoleInformation = applicationContext.Roles.FirstOrDefault(p => p.Code == "admin");
                            src.PermissionInformation = applicationContext.Permissions.FirstOrDefault(p => p.ID == i);
                            return src;
                        }));
                    }
                    await applicationContext.RoleAuthorizes.AddRangeAsync(lstAuthorizes);
                }
                // 初始化用户
                if (!await applicationContext.Users.AnyAsync())
                {
                    await applicationContext.Users.AddAsync(ApplicationFactory.Create<UserInfo>(func: src =>
                    {
                        src.Remarks = "管理员";
                        src.Account = "sysadmin";
                        src.Pwd = "a1234567";
                        src.Name = "吴嘉";
                        src.Gender = 0;
                        src.Age = 39;
                        src.Tel = "18673968186";
                        src.CreateDate = DateTime.Now;
                        return src;
                    }));
                }
                // 初始化用户角色
                if (!await applicationContext.UserRoles.AnyAsync())
                {
                    await applicationContext.UserRoles.AddAsync(ApplicationFactory.Create<UserRole>(func: src =>
                    {
                        src.RoleInfomation = applicationContext.Roles.FirstOrDefault(p => p.Code == "admin");
                        src.UserInfomation = applicationContext.Users.FirstOrDefault(p => p.Account == "sysadmin");
                        return src;
                    }));
                }
                // 初始化菜单
                if (!await applicationContext.Menus.AnyAsync())
                {
                    var lstMenu = new List<MenuInfo>
                    {
                        ApplicationFactory.Create<MenuInfo>(p =>
                        {
                            p.Remarks="暂无";
                            p.Title ="首页";
                            p.PathUrl ="/home/index";
                            p.Enabled =true;
                            return p;
                        }),
                        ApplicationFactory.Create<MenuInfo>(p =>
                        {
                            p.Remarks="暂无";
                            p.Title ="关于";
                            p.PathUrl ="/home/about";
                            p.Enabled =true;
                            return p;
                        })
                    };
                    await applicationContext.Menus.AddRangeAsync(lstMenu);
                }
                // 保存更改
                await applicationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
