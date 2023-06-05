using System.ComponentModel.DataAnnotations;

namespace LogService.DataAccessLayer.Models;

public class Log
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid GroupId { get; set; }
    public string Text { get; set; }
    public Guid StartSynchronizationId { get; set; }
    public Guid EndSynchronizationId { get; set; }
    public DateTimeOffset Created { get; set; }

    public Log()
    {
        
    }

    public Log(Guid userId, Guid groupId, string text, Guid startSynchronizationId, Guid endSynchronizationId)
    {
        this.UserId = userId;
        this.GroupId = groupId;
        this.Text = text;
        this.StartSynchronizationId = startSynchronizationId;
        this.EndSynchronizationId = endSynchronizationId;
    }
}