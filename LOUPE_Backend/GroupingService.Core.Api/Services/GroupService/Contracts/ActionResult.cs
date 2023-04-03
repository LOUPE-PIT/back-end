using System.Runtime.Serialization;

namespace GroupingService.Core.Api.Services.GroupService.Contracts;

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