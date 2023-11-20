using InvoiceManagementDatabase.Models;

namespace InvoiceManagementDatabase.Services
{
    public interface IInvoiceService
    {
        List<Invoice> Get();
        Invoice Get(string id);
        Invoice Create(Invoice invoice);
        void Update(String id, Invoice invoice);
        void Remove(String id);
    }
}
