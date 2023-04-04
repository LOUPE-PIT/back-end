using System.Runtime.Serialization;

namespace GroupingService.Core.Api.Services.GroupService.Contracts;

[DataContract]
public enum ActionResult
{
    [EnumMember(Value = "Succesvol")]
    Succesvol,
    
    [EnumMember(Value = "Onsuccesvol")]
    Onsuccesvol,
    
    [EnumMember(Value = "NietGevonden")]
    NietGevonden
}
