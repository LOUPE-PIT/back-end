namespace APIService.ViewModel
{
    public class FeedbackViewModel
    {
        private Guid guid { get; set; }
        private List<Guid> logIds { get; set; }
        private DateTime date { get; set; }
        private string text { get; set; }
    }
}
