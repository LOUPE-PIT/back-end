using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FeedbackService.DAL.Models
{
    [DataContract]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Guid FeedbackId { get; set; }
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public Guid LogId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string FeedbackText { get; set; }
    }
}
