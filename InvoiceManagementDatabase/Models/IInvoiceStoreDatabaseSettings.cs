namespace InvoiceManagementDatabase.Models
{
    public interface IInvoiceStoreDatabaseSettings
    {
        string InvoiceCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
