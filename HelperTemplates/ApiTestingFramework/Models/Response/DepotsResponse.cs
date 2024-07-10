using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace ApiTestingFramework.Models
{
    public class DepotsResponse
    {
        public DepotPayload[] depots { get; set; }
    }

    public class DepotPayload
    {
        public string LegacyId { get; set; }

        public string TypeId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid Key { get; set; }

        public string Name { get; set; }

        public string SourceSystem { get; set; }

        public string MessageEventType { get; set; }

        public DateTime MessageEventTimeStamp { get; set; }
    }
}
