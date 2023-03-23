namespace SynchronizationService.DataLayer
{
    public class ActionType
    {
        public string ObjectName { get; set; }
        public string ActionName { get; set; }

        public ActionType()
        {
            ActionName = nameof(ActionType);
        }
    }
}