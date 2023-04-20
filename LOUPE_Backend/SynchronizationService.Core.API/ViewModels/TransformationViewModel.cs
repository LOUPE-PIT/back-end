using SynchronizationService.Core.API.ViewModels.Actions;

namespace SynchronizationService.Core.API.ViewModels
{
    public class TransformationViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public bool IsLast { get; set; }
        public PerformedActionViewModel ActionType { get; set; } = null!;
        public TransformationViewModel()
        {

        }
    }
}
