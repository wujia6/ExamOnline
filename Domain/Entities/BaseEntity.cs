using System;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }

        public string Remarks { get; set; } = string.Empty;
    }
}
