using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GroupingService.DataAccessLayer.Models;

[DataContract]
public class ArchivedGroup
{
    [Key]
    [DataMember]
    public Guid Id { get; set; }

    /// <summary>
    /// The room code that can be used by a group to join the Unity env.
    /// </summary>
    [Required]
    [DataMember]
    public string RoomCode { get; set; }

    [DataMember]
    public Guid UserId { get; set; }
}