using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace CoffeeApplication.Model
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [BsonElement("totalPrice")]
        public decimal TotalPrice { get; set; } = 0;
        [BsonElement("paymentStatus")]
        public string PaymentStatus { get; set; } = string.Empty;
        [BsonElement("userid")]
        public string UserID { get; set; } = string.Empty;
        [BsonElement("orderitems")]
        [JsonPropertyName("orderitems")]
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
