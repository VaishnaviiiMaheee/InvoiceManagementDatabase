using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace InvoiceManagementDatabase.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [BsonElement("productId")]
        public string productId { get; set; }=String.Empty;

        [BsonElement("description")]
        public string Description { get; set; }= String.Empty;
        [BsonElement("price")]
        public decimal price { get;set; }=Decimal.MinValue;
    }
}
