using System.Collections.Generic;
using Domain.Entities.ClassAgg;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 教师实体类
    /// </summary>
    public class TeacherInfo : UserInfo
    {
        //专业
        public string Profssion { get; set; }
        //课程
        public int Course { get; set; }
        //导航属性
        public virtual IEnumerable<ClassTeacher> ClassTeachers { get; set; }
    }
}
