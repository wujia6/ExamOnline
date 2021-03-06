﻿using System;
using System.Collections.Generic;
using System.Linq;
using Domain.IComm;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 用户实体类（聚合根）
    /// </summary>
    public class UserInfo : BaseEntity, IAggregateRoot
    {
        //账号
        public string Account { get; set; }
        //密码
        public string Pwd { get; set; }
        //名字
        public string Name { get; set; }
        //性别
        public int Gender { get; set; }
        //年龄
        public int Age { get; set; }
        //电话
        public string Tel { get; set; }
        //创建日期
        public DateTime CreateDate { get; set; }
        //导航属性
        public virtual IEnumerable<UserRole> UserRoles { get; set; }
        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <returns></returns>
        public string GetRoles()
        {
            string roles = string.Empty;
            if (UserRoles == null || UserRoles.ToList().Count == 0)
                return roles;
            UserRoles.ToList().ForEach(x => roles += x.RoleInfomation.Code + ",");
            return roles.Remove(roles.LastIndexOf(','), 1);
        }
    }
}
