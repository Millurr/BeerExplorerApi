using BeerExplorerApi.Models;
using BeerExplorerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeerExplorerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BeerController : ControllerBase
{
    private readonly IItemService<Beer> _beerService;

    public BeerController(IItemService<Beer> beerService)
    {
        _beerService = beerService;
    }

    [HttpGet]
    public async Task<List<Beer>> Get() =>
        await _beerService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Beer>> Get(string id)
    {
        var beer = await _beerService.GetAsync(id);

        if (beer is null)
        {
            return NotFound();
        }

        return beer;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Beer newBeer)
    {
        await _beerService.CreateAsync(newBeer);

        return CreatedAtAction(nameof(Get), new { id = newBeer.Id }, newBeer);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Beer updatedBeer)
    {
        var beer = await _beerService.GetAsync(id);

        if (beer is null)
        {
            return NotFound();
        }

        updatedBeer.Id = beer.Id;

        await _beerService.UpdateAsync(id, updatedBeer);

        return CreatedAtAction(nameof(Get), new { id = updatedBeer.Id }, updatedBeer);
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var beer = await _beerService.GetAsync(id);

        if (beer is null)
        {
            return NotFound();
        }

        await _beerService.RemoveAsync(id);

        return NoContent();
    }

}