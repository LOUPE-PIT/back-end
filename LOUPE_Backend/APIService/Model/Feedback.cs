namespace APIService.Model
{
    public class Feedback
    {
        private Guid guid { get; set; }
        private List<Guid> logIds { get; set; }
        private DateTime date { get; set; }
        private string text { get; set; }
    }
}
