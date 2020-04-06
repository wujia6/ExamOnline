using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Utils
{
    public enum CommonEnum
    {
        //科目
        无 = 0,
        语文 = 1,
        数学 = 2,
        英语 = 3,
        计算机 = 4,
        C语言 = 5,
        //班级类型
        专业班 = 6,
        大专班 = 7,
        高考班 = 8,
        //教师类型
        班主任 = 9,
        教师 = 10,
        //题型
        填空题 = 11,
        选择题 = 12,
        多选题 = 13,
        判断题 = 14,
        问答题 = 15,
        计算题 = 16,
        //试题等级
        基本 = 17,
        中级 = 18,
        高级 = 19,
        //权限类型
        root = 20,
        module = 21,
        controller = 22,
        action = 23,
        //用户角色
        admin = 24,
        teacher = 25,
        student = 26,
        //年级
        一年级=27,
        二年级=28,
        三年级=29,
        //班级状态
        已启用=30,
        未启用=31,
        //性别
        帅哥=32,
        美女=33
    }

    public class CommonUtils
    {
        /// <summary>
        /// 获取指定枚举值并封装SelectList
        /// </summary>
        /// <param name="start">开始枚举值/param>
        /// <param name="end">结束枚举值</param>
        /// <returns></returns>
        public static SelectList EnumToSelect(int start, int end)
        {
            var items = new List<SelectListItem>();
            foreach (int e in Enum.GetValues(typeof(CommonEnum)))
            {
                if (e >= start && e <= end)
                {
                    string eName = Enum.GetName(typeof(CommonEnum), e);
                    var itm = new SelectListItem(eName, e.ToString());
                    items.Add(itm);
                }
            }
            //items.Insert(0, new SelectListItem { Text = firstText, Value = "0" });
            return new SelectList(items.AsEnumerable(), "Value", "Text", 0);
        }

        /// <summary>
        /// 初始化下拉框数据
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="textField">显示文本字段，默认"Name"字段</param>
        /// <param name="valueField">绑定值字段，默认"ID"字段</param>
        /// <param name="firstText">首项显示文本，默认”===默认===“</param>
        /// <returns>SelectList</returns>
        public static SelectList DorpDownInit<T>(List<T> source, string textField = "Name", string valueField = "ID")
        {
            if (source==null || source.Count==0)
                throw new ArgumentNullException("source", "初始化下拉框的数据源为空或无数据");
            var ddl = new SelectList(source, valueField, textField,0);
            //ddl.ToList().Insert(0, new SelectListItem { Text = firstText, Value = "0" });
            return ddl;
        }

        /// <summary>
        /// 获取指定枚举值的名称
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns></returns>
        public static string GetCommonEnumName(int enumValue)
        {
            return Enum.GetName(typeof(CommonEnum), enumValue);
        }

        /// <summary>
        /// 通用递归方法
        /// </summary>
        /// <param name="srcList">数据源</param>
        /// <param name="levelId">层级ID</param>
        /// <returns></returns>
        public static List<T> Recursion<T>(List<T> srcList, int levelId = 0) where T : class
        {
            if (srcList == null || srcList.Count == 0)
                return null;
            var matchs = srcList.Where(x => { dynamic cls = x; return cls.LevelID == levelId ? true : false; });
            if (matchs != null && matchs.Count() > 0)
            {
                foreach (dynamic item in matchs)
                    item.Childs = Recursion(srcList, item.ID);
            }
            return matchs.ToList();
        }
    }
}
