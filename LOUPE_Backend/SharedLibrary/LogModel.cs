using System.ComponentModel.DataAnnotations;

namespace SharedLibrary
{
    public class LogModel
    {
        // Model used to define in the messaging process. Needs to be the same model with the same values as in the recieving microservice.
        [Key]
        public string logId { get; set; }
        //[ForeignKey("User")]
        public string userId { get; set; }
        public string log { get; set; }
    }
}
