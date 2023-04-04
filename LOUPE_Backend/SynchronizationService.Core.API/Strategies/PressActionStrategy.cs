using SynchronizationService.Core.API.Services;
using SynchronizationService.Core.API.ViewModels;

namespace SynchronizationService.Core.API.Strategies
{
    public class PressActionStrategy : IActionStrategy
    {
        private readonly ISynchronizationService _syncService;
        public PressActionStrategy(ISynchronizationService service)
        {
            _syncService = service;
        }

        public async Task AddAction(TransformationViewModel transformation)
        {
            await _syncService.Add(transformation);
        }
    }
}
