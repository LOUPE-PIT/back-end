using System.Runtime.Serialization;

namespace LogService.Core.Api.Contracts;

[DataContract]
public enum ActionResult
{
    [DataMember]
    Succesvol,
    
    [DataMember]
    Onsuccesvol,
    
    [DataMember]
    NietGevonden
}