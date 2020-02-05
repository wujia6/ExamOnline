using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender
    {
        男 = 0,
        女 = 1
    }

    /// <summary>
    /// 班级状态
    /// </summary>
    public enum ClassStatus
    {
        未启用 = 0,
        已启用 = 1
    }

    /// <summary>
    /// 年级
    /// </summary>
    public enum ClassGrade
    {
        一年级 = 1,
        二年级 = 2,
        三年级 = 3
    }

    /// <summary>
    /// 公用类型
    /// </summary>
    public enum CommType
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
        基本=17,
        中级=18,
        高级=19,
        //菜单类型
        菜单=20,
        模块=21,
        控制器=22,
        功能=23,
        //用户角色
        admin=24,
        teacher=25,
        student=26
    }
}
