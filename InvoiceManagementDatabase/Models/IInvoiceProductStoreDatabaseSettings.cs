namespace InvoiceManagementDatabase.Models
{
    public interface IInvoiceProductStoreDatabaseSettings
    {
        string InvoiceProductCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
