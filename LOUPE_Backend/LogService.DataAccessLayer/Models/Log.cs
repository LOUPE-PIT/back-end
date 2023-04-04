using System.ComponentModel.DataAnnotations;

namespace LogService.DataAccessLayer.Models;

public class Log
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid GroupId { get; set; }
    public string Text { get; set; }
    public DateTimeOffset Created { get; set; }

    public Log()
    {
        
    }
}