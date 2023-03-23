using SynchronizationService.DataLayer.Models.MongoDB.Interfaces;

namespace SynchronizationService.DataLayer.Models.MongoDB
{
    public class TransformationsDatabaseSettings : ITransformationsDatabaseSettings
    {
        public string TransformationsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
