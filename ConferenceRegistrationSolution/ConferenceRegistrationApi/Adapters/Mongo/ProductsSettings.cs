namespace ConferenceRegistrationApi.Adapters;

public class ProductsSettings
{
    public static string SectionName = "ProductsSection";
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string CollectionName { get; set; } = string.Empty;
}
