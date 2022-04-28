using System.ComponentModel.DataAnnotations;

namespace LogHandler.Microservice.Model
{
    public class LogModel
    {
        [Key]
        public string logId { get; set; }
        public string userId { get; set; }
        public string log { get; set; }
        public DateTime created { get; set; }
    }
}
