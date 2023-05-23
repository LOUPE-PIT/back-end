using SynchronizationService.Core.API.Services;
using SynchronizationService.Core.API.ViewModels;

namespace SynchronizationService.Core.API.Strategies
{
    public class TranslationActionStrategy : IActionStrategy
    {
        private readonly ISynchronizationService _syncService;

        private static TransformationViewModel lastTransformation = null!;
        public TranslationActionStrategy(ISynchronizationService service)
        {
            _syncService = service;
        }

        public string Name => throw new NotImplementedException();

        public async Task<bool> AddAction(TransformationViewModel transformation)
        {
            if (lastTransformation is not null ? transformation.ActionType.XPos == lastTransformation.ActionType.XPos &&
                transformation.ActionType.YPos == lastTransformation.ActionType.YPos &&
                transformation.ActionType.ZPos == lastTransformation.ActionType.ZPos : false)
                return false;
            
            await _syncService.Add(transformation);
            lastTransformation = transformation;
            return true;
        }
    }
}
