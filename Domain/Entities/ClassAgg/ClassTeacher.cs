using System;

namespace Domain.Entities.ClassAgg
{
    public class ClassTeacher : ClassRoot
    {
        public override Guid ID { get; set; }

        public virtual ClassInfo ClassInfo { get; set; }

        public virtual UserAgg.Teacher Teacher { get; set; }
    }
}
