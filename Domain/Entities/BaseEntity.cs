using System;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public abstract Guid ID { get; set; }

        public abstract string Remarks { get; set; }
    }
}
