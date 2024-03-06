using BeerExplorerApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BeerExplorerApi.Services;

public interface IItemService<T>
{

    public Task<List<T>> GetAsync();

    public Task<T?> GetAsync(string id);

    public Task CreateAsync(T newItem);

    public Task UpdateAsync(string id, T updatedItem);

    public Task RemoveAsync(string id);

}