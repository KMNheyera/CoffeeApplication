using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoffeeApplication.Model
{
    public class OrderItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("productid")]
        public string ProductID { get; set; } = string.Empty;
        [BsonElement("quantity")]
        public int Quantity { get; set; } = 0;
        [BsonElement("subtotalprice")]
        public decimal SubtotalPrice { get; set; } = 0;
    }
}
