using SynchronizationService.DataLayer.Models;

namespace SynchronizationService.DataLayer.Services.Interface
{
    public interface ITransformationRepository
    {
        public List<Transformation> Get();
        public Transformation Get(Guid id);
        public Task<Transformation> Create(Transformation transformation);
        public void Update(Transformation transformation);
        public void Delete(Transformation transformation);
    }
}
