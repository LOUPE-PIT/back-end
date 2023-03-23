using SynchronizationService.Core.API.ViewModels.Actions;

namespace SynchronizationService.Core.API.ViewModels
{
    public class TransformationViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string RoomCode { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public ActionType ActionType { get; set; }
    }
}
