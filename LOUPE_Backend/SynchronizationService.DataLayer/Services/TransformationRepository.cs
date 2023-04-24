using MongoDB.Driver;
using SynchronizationService.DataLayer.Models;
using SynchronizationService.DataLayer.Models.MongoDB.Interfaces;
using SynchronizationService.DataLayer.Services.Interface;

namespace SynchronizationService.DataLayer.Services
{
    public class TransformationRepository : ITransformationRepository
    {
        private readonly IMongoCollection<Transformation> _transformations;

        public TransformationRepository(ITransformationsDatabaseSettings settings, IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);
            _transformations = database.GetCollection<Transformation>(settings.TransformationsCollectionName);
        }

        public async Task<bool> Create(Transformation transformation)
        {
            try
            {
                await _transformations.InsertOneAsync(transformation);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Transformation transformation)
        {
            _transformations.DeleteOne(t =>  transformation.Id == t.Id);
        }

        public List<Transformation> Get()
        {
            return _transformations.Find(transformation => true).ToList();

        }

        public Transformation Get(Guid id)
        {
            return _transformations.Find(transformation => transformation.Id == id).FirstOrDefault();
        }

        public void Update(Transformation transformation)
        {
            throw new NotImplementedException();
        }
    }
}
