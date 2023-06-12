namespace FeedbackService.API.Core.Viewmodels
{
    public class FeedbackViewmodel
    {
        public Guid? FeedbackId { get; set; }

        public Guid UserId { get; set; }

        public Guid LogId { get; set; }

        public DateTime Date { get; set; }

        public string FeedbackText { get; set; }


    }
}




