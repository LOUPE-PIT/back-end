namespace SynchronizationService.Core.API.ViewModels.Actions
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