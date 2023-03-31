using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CoffeeApplication.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("productname")]
        public string ProductName { get; set; } = string.Empty;
        [BsonElement("productdescription")]
        public string ProductDescription { get; set; } = string.Empty;
        [BsonElement("price")]
        public decimal Price { get; set; } = 0;
        [BsonElement("imageurl")]
        public string ImageURL { get; set; } = string.Empty;
    }

}
