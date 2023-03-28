using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GroupingService.Core.Api.ViewModels;

[DataContract]
public class GroupRequestBody
{
    [DataMember]
    public string RoomCode { get; set; } = null!;
    
    [DataMember]
    public Collection<Guid> UserIds { get; set; }
}