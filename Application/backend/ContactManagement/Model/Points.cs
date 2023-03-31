using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoffeeApplication.Model
{
    public class Points
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("userid")]
        public string UserId { get; set; } = string.Empty;
        [BsonElement("pointsearned")]
        public int PointsEarned { get; set; } = 0;
        [BsonElement("pointsspent")]
        public int PointsSpent { get; set; } = 0;
        [BsonElement("lastearneddate")]
        public DateTime LastEarnedDate { get; set; } = DateTime.Now;
        [BsonElement("lastspentdate")]
        public DateTime LastSpentDate { get; set; } = DateTime.Now;
    }
}
