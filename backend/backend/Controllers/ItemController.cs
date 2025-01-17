using API.DTOModels;
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
        [Route("items")]
        public async Task<IActionResult> GetItems()   // The Get() method uses the _itemService.GetItems() method to fetch the list of items. This is an asynchronous operation, so it uses await to wait for the result.
        {
            var items = await _itemService.GetItems();

            if (items == null || !items.Any())
            {
                return NotFound();  // Return 404 if no items found
            }

            // map each Item domain model to ItemDTO model
            var itemDTOs = items.Select(item => ItemMapperDomainToDTO.MapToDTO(item)).ToList();

            return Ok(itemDTOs); // the list of ItemDTO objects is returned with a 200 OK response            
        }

        [HttpGet]
        [Route("item/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await _itemService.GetItemById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [Route("addItem")]
        public async Task<IActionResult> AddItem([FromBody] ItemDTO itemDTO)
        {
            if (itemDTO == null)
            {
                return BadRequest("Item data is null");
            }

            var item = ItemMapperDTOToDomain.MapToDomain(itemDTO);  // mapping dto to domain and passing it to service

            await _itemService.AddItem(item);   // passing domain to service

            return Ok();  
        }

        [HttpDelete]
        [Route("deleteItem/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemService.DeleteItem(id);
            
            return Ok();
        }

        [HttpPut]
        [Route("editItem/{id}")]
        public async Task<IActionResult> EditItem(int id, [FromBody] ItemDTO itemDTO)
        {
            if (id != itemDTO.Id)
            {
                return BadRequest();
            }

            var item = ItemMapperDTOToDomain.MapToDomain(itemDTO);  // mapping dto to domain and passing it to service

            await _itemService.EditItem(item);  // passing domain to service

            return Ok();
        }
    }
}
