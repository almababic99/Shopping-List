using API.DTOModels;
using API.Mappers;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]  // route for this controller will be /api/shoppinglist
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;
        private readonly IShopperService _shopperService;
        private readonly IItemService _itemService;

        public ShoppingListController(IShoppingListService shoppingListService, IShopperService shopperService, IItemService itemService)  // Constructor for Dependency Injection 
        {
            _shoppingListService = shoppingListService;
            _shopperService = shopperService;
            _itemService = itemService;
        }

        [HttpGet]
        [Route("shoppingLists")]

        public async Task<IActionResult> GetShoppingLists()
        {
            var shoppingLists = await _shoppingListService.GetShoppingLists();

            // Check if the result is null or empty and return appropriate response
            if (shoppingLists == null || !shoppingLists.Any())
            {
                return NotFound();  // Return 404 if no shopping lists found
            }

            // Using ShoppingListMapper from API.Mappers to map each ShoppingList domain model to ShoppingListDTO model
            var shoppingListsDTOs = new List<ShoppingListDTO>();

            foreach (var shoppingList in shoppingLists)
            {
                var shoppingListDTO = await ShoppingListMapperDomainToDTO.MapToDTO(shoppingList, _shopperService, _itemService);
                shoppingListsDTOs.Add(shoppingListDTO);
            }

            return Ok(shoppingListsDTOs); // the list of ShoppingListsDTO objects is returned with a 200 OK response    
        }
    }
}
