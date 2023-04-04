using System.Runtime.Serialization;

namespace LogService.Core.Api.Contracts;

[DataContract]
public enum ActionResult
{
    [DataMember]
    [EnumMember(Value = "Succesvol")]
    Succesvol,
    
    [DataMember]
    [EnumMember(Value = "Onsuccesvol")]
    Onsuccesvol,
    
    [DataMember]
    [EnumMember(Value = "NietGevonden")]
    NietGevonden
}