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
        public string RoomCode { get; set; }
        [BsonDateTimeOptions(DateOnly = false, Kind = DateTimeKind.Utc, Representation = BsonType.DateTime)]
        public DateTimeOffset TimeStamp { get; set; }
        public ActionType ActionType { get; set; }
    }
}
