using InvoiceManagementDatabase.Models;
using MongoDB.Driver;

namespace InvoiceManagementDatabase.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IProductStoreDatabaseSettings settings, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>(settings.ProductCollectionName);
        }
        public Product Create(Product product)
        {
            product.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            _products.InsertOne(product);
            return product;
        }

        public List<Product> Get()
        {
            return _products.Find(product => true).ToList();
        }

        public Product Get(string id)
        {

           return _products.Find(product => product.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _products.DeleteOne(product => product.Id == id);
        }

        public void Update(string id, Product product)
        {
            _products.ReplaceOne(product => product.Id == id, product);
        }
    }
}
