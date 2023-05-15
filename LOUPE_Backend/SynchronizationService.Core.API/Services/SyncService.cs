using AutoMapper;
using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.DataLayer.Models;
using SynchronizationService.DataLayer.Services.Interface;

namespace SynchronizationService.Core.API.Services
{
    public class SyncService : ISynchronizationService
    {
        private readonly ITransformationRepository _context;
        private readonly IMapper _mapper;
        public SyncService(ITransformationRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(TransformationViewModel transformation)
        {
            Transformation newTransformation = _mapper.Map<Transformation>(transformation);
            await _context.Create(newTransformation);
        }
    }
}
