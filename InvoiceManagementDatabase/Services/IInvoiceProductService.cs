using InvoiceManagementDatabase.Models;

namespace InvoiceManagementDatabase.Services
{
    public interface IInvoiceProductService
    {
        List<InvoiceProduct> Get();
        InvoiceProduct Get(string id);
        InvoiceProduct Create(InvoiceProduct invoiceproduct);
        void Update(String id, InvoiceProduct invoiceproduct);
        void Remove(String id);
    }
}
