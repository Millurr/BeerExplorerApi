namespace BeerExplorerApi.Models;

public class BeerExplorerDatabaseSettings
{
    public string BeerCollectionName { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}