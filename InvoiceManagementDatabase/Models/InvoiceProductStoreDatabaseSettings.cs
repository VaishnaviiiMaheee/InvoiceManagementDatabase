namespace InvoiceManagementDatabase.Models
{
    public class InvoiceProductStoreDatabaseSettings:IInvoiceProductStoreDatabaseSettings
    {
        public string InvoiceProductCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
