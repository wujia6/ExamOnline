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
    /// 教师类型
    /// </summary>
    public enum TeacherType
    {
        班主任 = 1,
        教师 = 2
    }

    /// <summary>
    /// 科目
    /// </summary>
    public enum Subject
    {
        无 = 0,
        语文 = 1,
        数学 = 2,
        英语 = 3,
        计算机 = 4,
        C语言 = 5
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
    /// 类别
    /// </summary>
    public enum ClassCategory
    {
        专业班 = 1,
        大专班 = 2,
        高考班 = 3
    }
}
