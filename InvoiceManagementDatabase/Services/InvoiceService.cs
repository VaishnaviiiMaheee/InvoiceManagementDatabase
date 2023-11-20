using InvoiceManagementDatabase.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InvoiceManagementDatabase.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMongoCollection<Invoice> _invoices;
        public InvoiceService(IInvoiceStoreDatabaseSettings settings, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _invoices = database.GetCollection<Invoice>(settings.InvoiceCollectionName);
        }
        public Invoice Create(Invoice invoice)
        {
            invoice.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            invoice.CustomerId = ObjectId.Parse(invoice.CustomerId.ToString());
            _invoices.InsertOne(invoice);
            return invoice;
        }

        public List<Invoice> Get()
        {
            return _invoices.Find(invoice => true).ToList();
        }

        public Invoice Get(string id)

        {
            return _invoices.Find(invoice => invoice.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _invoices.DeleteOne(invoice => invoice.Id == id);
        }

        public void Update(string id, Invoice invoice)
        {
            _invoices.ReplaceOne(invoice => invoice.Id == id, invoice);
        }
    }
}
