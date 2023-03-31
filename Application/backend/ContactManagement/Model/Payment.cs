using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoffeeApplication.Model
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("paymentdate")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        [BsonElement("amount")]
        public double Amount { get; set; } = 0;
        [BsonElement("paymentmethod")]
        public string PaymentMethod { get; set; } = string.Empty;
        [BsonElement("userid")]
        public string UserID { get; set; } = string.Empty;
    }
}
