using AutoMapper;
using SynchronizationService.Core.API.Profiles;
using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.DataLayer.Models;
using SynchronizationService.DataLayer.Services.Interface;

namespace SynchronizationService.Core.API.Services
{
    public class SyncService : ISynchronizationService
    {
        private readonly ITransformationRepository _context;
        private readonly Mapper _mapper;
        public SyncService(ITransformationRepository context)
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ActionProfile>();
                cfg.AddProfile<TransformationProfile>();
            }));

            _context = context;
        }

        public async Task Add(TransformationViewModel transformation)
        {
            Transformation newTransformation = _mapper.Map<Transformation>(transformation);
            await _context.Create(newTransformation);
        }
    }
}
