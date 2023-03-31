using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoffeeApplication.Model
{
        public class PointsSettings
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; } = string.Empty;
            [BsonElement("pointsrate")]
            public double PointsRate { get; set; } = 0;
            [BsonElement("pointscap")]
            public int PointsCap{ get; set; } = 0;
            [BsonElement("datecreated")]
            public DateTime DateCreated { get; set; } = DateTime.Now;
        }

}
