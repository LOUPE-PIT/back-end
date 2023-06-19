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
            await _syncService.Add(transformation);
            lastTransformation = transformation;
            return true;
        }
    }
}
