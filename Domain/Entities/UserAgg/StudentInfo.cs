using System.Collections.Generic;
using Domain.Entities.AnwserAgg;
using Domain.Entities.ClassAgg;

namespace Domain.Entities.UserAgg
{
    /// <summary>
    /// 学生实体类
    /// </summary>
    public class StudentInfo : UserInfo
    {
        //学号
        public string StudentNo { get; set; }
        //身份证
        public string IdentityNo { get; set; }
        //监护人电话
        public string ParentTel { get; set; }
        //地区
        public string District { get; set; }
        //地址
        public string Address { get; set; }
        //寝室号
        public string Dormitory { get; set; }
        //导航属性
        public ClassInfo ClassInfomation { get; set; }
        //导航属性
        public virtual IEnumerable<AnswerInfo> AnswerInfomations { get; set; }
    }
}
