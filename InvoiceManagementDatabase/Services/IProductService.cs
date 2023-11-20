using InvoiceManagementDatabase.Models;

namespace InvoiceManagementDatabase.Services
{
    public interface IProductService
    {
        List<Product> Get();
        Product Get(string id);
        Product Create(Product product);
        void Update(String id, Product product);
        void Remove(String id);
    }
}
