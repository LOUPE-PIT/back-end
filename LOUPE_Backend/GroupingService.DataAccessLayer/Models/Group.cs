using System.ComponentModel.DataAnnotations;

namespace GroupingService.DataAccessLayer.Models;

public class Group
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string RoomCode { get; set; }
}