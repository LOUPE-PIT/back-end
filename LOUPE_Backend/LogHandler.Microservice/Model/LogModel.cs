using System.ComponentModel.DataAnnotations;

namespace LogHandler.Microservice.Model
{
    public class LogModel
    {
        [Key]
        public int logId { get; set; }
        public int userId { get; set; }
        public string log { get; set; }
        public DateTime created { get; set; }
    }
}
