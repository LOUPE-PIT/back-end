using SynchronizationService.Core.API.ViewModels;

namespace SynchronizationService.Core.API.Strategies
{
    public interface IActionStrategy
    {
        public Task<bool> AddAction(TransformationViewModel transformation);
    }
}
