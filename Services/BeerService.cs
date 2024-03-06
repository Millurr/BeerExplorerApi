

using BeerExplorerApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BeerExplorerApi.Services;

public class BeerService : IItemService<Beer>
{
    private readonly IMongoCollection<Beer> _beersCollection;

    public BeerService(IOptions<BeerExplorerDatabaseSettings> beerExplorerDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            beerExplorerDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            beerExplorerDatabaseSettings.Value.DatabaseName);

        _beersCollection = mongoDatabase.GetCollection<Beer>(
            beerExplorerDatabaseSettings.Value.BeerCollectionName);
    }

    public async Task<List<Beer>> GetAsync() =>
        await _beersCollection.Find(_ => true).ToListAsync();

    public async Task<Beer?> GetAsync(string id) =>
        await _beersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Beer newBeer) =>
        await _beersCollection.InsertOneAsync(newBeer);

    public async Task UpdateAsync(string id, Beer updatedBeer) =>
        await _beersCollection.ReplaceOneAsync(x => x.Id == id, updatedBeer);

    public async Task RemoveAsync(string id) =>
        await _beersCollection.DeleteOneAsync(x => x.Id == id);
}