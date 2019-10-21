using System.Runtime.Serialization;

namespace Application.DTO
{
    public abstract class UserRootDTO
    {
        [DataMember]
        int ID { get; set; }

        [DataMember]
        string Remarks { get; set; }
    }
}
