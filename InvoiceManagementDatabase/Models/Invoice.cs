using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InvoiceManagementDatabase.Models
{
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("invoiceNumber")]
        public string InvoiceNumber { get; set; } = String.Empty;

        [BsonElement("customerId")]
        public ObjectId CustomerId { get; set; }

        [BsonElement("remarks")]
        public string Remarks { get; set; } = String.Empty;

        [BsonElement("total")]
        public decimal Total { get; set; }

        [BsonElement("tax")]
        public decimal Tax { get; set; }

        [BsonElement("netTotal")]
        public decimal NetTotal { get; set; }

        [BsonElement("status")]
        public string Status { get; set; } = String.Empty;

        [BsonElement("customerName")]
        public string CustomerName { get; set; } = String.Empty;

        [BsonElement("deliveryAddress")]
        public string DeliveryAddress { get; set; } = String.Empty;

        [BsonElement("details")]
        public List<Details> Details { get; set; } = new List<Details>();

    }
    public class Details
    {
        [BsonElement("invoiceNo")]
        public string InvoiceNo { get; set; } = String.Empty;
        [BsonElement("productCode")]
        public string ProductCode { get; set; } = String.Empty;
        [BsonElement("productId")]
        public string ProductId { get; set; } = String.Empty;
        [BsonElement("productName")]
        public string ProductName { get; set; } = String.Empty;

        [BsonElement("qty")]
        public decimal Qty { get; set; }
        [BsonElement("price")]
        public decimal SalesPrice { get; set; }
    }

}
