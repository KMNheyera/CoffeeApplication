using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace CoffeeApplication.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("firstName")]
        public string FirstName { get; set; } = string.Empty;
        [BsonElement("lastName")]
        public string LastName { get; set; } = string.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
        [BsonElement("coffeesbought")]
        public int CoffeesBought { get; set; } = 0;
        [BsonElement("pointsearned")]
        public int PointsEarned { get; set; } = 0;
        [BsonElement("pointsspent")]
        public int PointsSpent { get; set; } = 0;
        [BsonElement("lastearneddate")]
        public double Credit { get; set; } = 0;
        [BsonElement("credit")]
        public DateTime LastEarnedDate { get; set; } = DateTime.Now;
        [BsonElement("lastspentdate")]
        public DateTime LastSpentDate { get; set; } = DateTime.Now;
    }
}
