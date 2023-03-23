using SynchronizationService.DataLayer.Models;

namespace SynchronizationService.DataLayer.Services.Interface
{
    public interface ITransformationService
    {
        public List<Transformation> Get();
        public Transformation Get(Guid id);
        public Transformation Create(Transformation transformation);
        public void Update(Transformation transformation);
        public void Delete(Transformation transformation);
    }
}
