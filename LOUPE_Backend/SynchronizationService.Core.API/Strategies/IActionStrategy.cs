using SynchronizationService.Core.API.ViewModels;

namespace SynchronizationService.Core.API.Strategies
{
    public interface IActionStrategy
    {
        public string Name { get; }
        public Task<bool> AddAction(TransformationViewModel transformation);
    }
}
