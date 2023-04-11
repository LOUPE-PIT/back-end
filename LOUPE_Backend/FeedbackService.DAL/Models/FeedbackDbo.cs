using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FeedbackService.DAL.Models
{
    [DataContract]
    public class FeedbackDbo
    {
        [Key]
        [DataMember]
        public Guid FeedbackId { get; set; }
        //public Collection<Guid> LogIds { get; set; }
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string FeedbackText { get; set; }
    }
}
