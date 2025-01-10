using API.Mappers;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]  // route for this controller will be /api/item
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)  // Constructor for Dependency Injection of IItemService
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()   // The Get() method uses the _itemService.GetItems() method to fetch the list of items. This is an asynchronous operation, so it uses await to wait for the result.
        {
            var items = await _itemService.GetItems();

            // Check if the result is null or empty and return appropriate response
            if (items == null || !items.Any())
            {
                return NotFound();  // Return 404 if no items found
            }

            // Using ItemMapper from API.Mappers to map each Item domain model to ItemDTO model
            var itemDTOs = items.Select(itemDomain => ItemMapperDomainToDTO.MapToDTO(itemDomain)).ToList();

            return Ok(itemDTOs); // the list of ItemDTO objects is returned with a 200 OK response            
        }
    }
}
