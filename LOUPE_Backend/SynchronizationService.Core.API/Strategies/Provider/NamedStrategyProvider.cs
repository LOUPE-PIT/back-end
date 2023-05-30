using SynchronizationService.Core.API.ViewModels;

namespace SynchronizationService.Core.API.Strategies.Provider
{
    public class NamedStrategyProvider : IActionStrategy
    {
        private readonly string _name;
        private readonly IActionStrategy _strategy;

        public NamedStrategyProvider(string name, IActionStrategy strategy)
        {
            _name = name;
            _strategy = strategy;
        }

        public string Name => _name;

        public async Task<bool> AddAction(TransformationViewModel transformation)
        {
            return await _strategy.AddAction(transformation);
        }
    }

}
