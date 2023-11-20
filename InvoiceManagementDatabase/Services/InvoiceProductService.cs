using InvoiceManagementDatabase.Models;
using MongoDB.Driver;

namespace InvoiceManagementDatabase.Services
{
    public class InvoiceProductService : IInvoiceProductService
    {
        private readonly IMongoCollection<InvoiceProduct> _invoiceproducts;

        public InvoiceProductService(IInvoiceProductStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _invoiceproducts = database.GetCollection<InvoiceProduct>(settings.InvoiceProductCollectionName);
        }
        public InvoiceProduct Create(InvoiceProduct invoiceproduct)
        {
            invoiceproduct.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            _invoiceproducts.InsertOne(invoiceproduct);
            return invoiceproduct;
        }

        public List<InvoiceProduct> Get()
        {
            return _invoiceproducts.Find(invoiceproduct => true).ToList();
        }

        public InvoiceProduct Get(string id)
        {
            return _invoiceproducts.Find(invoiceproduct => invoiceproduct.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _invoiceproducts.DeleteOne(invoiceproduct => invoiceproduct.Id == id);
        }

        public void Update(string id, InvoiceProduct invoiceproduct)
        {
            _invoiceproducts.ReplaceOne(invoiceproduct => invoiceproduct.Id == id, invoiceproduct);
        }
    }
}
