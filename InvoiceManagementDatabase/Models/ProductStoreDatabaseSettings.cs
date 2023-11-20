namespace InvoiceManagementDatabase.Models
{
    public class ProductStoreDatabaseSettings:IProductStoreDatabaseSettings
    {
        public string ProductCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
