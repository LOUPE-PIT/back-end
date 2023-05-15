using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SynchronizationService.DataLayer.Models
{
    public class Transformation
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid UserId { get; set; }
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid GroupId { get; set; }
        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset TimeStamp { get; set; }
        public PerformedAction ActionType { get; set; } = null!;
    }
}
