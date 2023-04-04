using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace GroupingService.Core.Api.ViewModels;

[DataContract]
public class GroupRequestBody
{
    [DataMember]
    public Collection<Guid> UserIds { get; set; }
}