using SynchronizationService.Core.API.Services;
using SynchronizationService.Core.API.ViewModels;

namespace SynchronizationService.Core.API.Strategies
{
    public class TranslationActionStrategy : IActionStrategy
    {
        private readonly ISynchronizationService _syncService;

        private TransformationViewModel lastTransformation = null!;
        public TranslationActionStrategy(ISynchronizationService service)
        {
            _syncService = service;
        }

        public async Task<bool> AddAction(TransformationViewModel transformation)
        {
            if (transformation.ActionType.XPos == lastTransformation.ActionType.XPos &&
                transformation.ActionType.YPos == lastTransformation.ActionType.YPos &&
                transformation.ActionType.ZPos == lastTransformation.ActionType.ZPos)
                return false;
            
            await _syncService.Add(transformation);
            lastTransformation = transformation;
            return true;
        }
    }
}
