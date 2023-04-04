using MongoDB.Driver;
using SynchronizationService.Core.API.Services;
using SynchronizationService.Core.API.ViewModels;

namespace SynchronizationService.Core.API.Strategies
{
    public class RotationActionStrategy : IActionStrategy
    {
        private readonly ISynchronizationService _syncService;

        private TransformationViewModel lastTransformation = null!;
        public RotationActionStrategy(ISynchronizationService service)
        {
            _syncService = service;
        }

        public async Task<bool> AddAction(TransformationViewModel transformation)
        {
            if (transformation.ActionType.Degrees == lastTransformation.ActionType.Degrees)
                return false;

            await _syncService.Add(transformation);
            lastTransformation = transformation;
            return true;
        }
    }
}
