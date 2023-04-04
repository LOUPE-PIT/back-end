using System.Runtime.Serialization;

namespace GroupingService.Core.Api.Services.GroupService.Contracts;

[DataContract]
public class GroupActionResponse
{
    [DataMember]
    public ActionResult? Result { get; set; }

    [DataMember] 
    public string? ResultString { get; set; } = null!;
}