using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GroupingService.DataAccessLayer.Models;

[DataContract]
public class Group
{
    /// <summary>
    /// The room code that can be used by a group to join the Unity env.
    /// </summary>
    /// <remarks>
    /// Also acts as the primary key of the table
    /// </remarks>
    [Key]
    [DataMember]
    public string RoomCode { get; set; }

    [DataMember]
    public Guid UserId { get; set; }

}