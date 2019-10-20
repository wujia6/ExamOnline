using System.Collections.Generic;
using System.Linq;
using Domain.Entities.ClassAgg;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 教师实体类
    /// </summary>
    public class TeacherInfo : UserRoot
    {
        /// <summary>
        /// 专业
        /// </summary>
        public string Profssion { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        public CommType Course { get; set; } = CommType.C语言;

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual IQueryable<ClassTeacher> ClassTeachers { get; set; } = new List<ClassTeacher>().AsQueryable();
    }
}
