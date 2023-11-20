namespace InvoiceManagementDatabase.Models
{
    public class InvoiceStoreDatabaseSettings:IInvoiceStoreDatabaseSettings
    {
        public string InvoiceCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
