using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace InvoiceManagementDatabase.Models
{
    public class InvoiceProduct
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("invoiceId")]
        public ObjectId InvoiceId { get; set; }

        [BsonElement("productId")]
        public ObjectId ProductId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("total")]
        public decimal Total { get; set; }
    }
}
