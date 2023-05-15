﻿using MongoDB.Driver;
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
            await _transformations.InsertOneAsync(transformation);
            return true;
        }

        public void Delete(Transformation transformation)
        {
            _transformations.DeleteOne(t => t.Id == transformation.Id);
        }

        public List<Transformation> Get()
        {
            return _transformations.Find(t => true).ToList();

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
