using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SynchronizationService.DataLayer.Models;
using SynchronizationService.DataLayer.Services.Interface;

namespace SynchronizationService.DataLayer.Services
{
    public class TransformationService : ITransformationService
    {
        private readonly IMongoCollection<Transformation> _transformations;

        public TransformationService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            IMongoClient client = new MongoClient(configuration.GetSection("MongoDb:connectionstring").Value);

            IMongoDatabase database = client.GetDatabase(configuration.GetSection("MongoDb:databaseName").Value);
            _transformations = database.GetCollection<Transformation>(configuration.GetSection("MongoDb:synchronizationCollectionName").Value);
        }
        public Transformation Create(Transformation transformation)
        {
            _transformations.InsertOne(transformation);
            return transformation;
        }

        public void Delete(Transformation transformation)
        {
            _transformations.DeleteOne(transformation =>  transformation.Id == transformation.Id);
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
