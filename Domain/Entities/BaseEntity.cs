using System.Runtime.Serialization;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Remarks { get; set; }
    }
}
