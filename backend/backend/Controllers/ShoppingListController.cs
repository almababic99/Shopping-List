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

            if (shoppingLists == null || !shoppingLists.Any())
            {
                return NotFound();  // Return 404 if no shopping lists found
            }

            // map each ShoppingList domain model to ShoppingListDTO model
            var shoppingListsDTOs = new List<ShoppingListDTO>();

            foreach (var shoppingList in shoppingLists)
            {
                var shoppingListDTO = await ShoppingListMapperDomainToDTO.MapToDTO(shoppingList, _shopperService, _itemService);
                shoppingListsDTOs.Add(shoppingListDTO);
            }

            return Ok(shoppingListsDTOs); // the list of ShoppingListsDTO objects is returned with a 200 OK response    
        }

        [HttpGet]
        [Route("shoppingLists/{shopperId}")]
        public async Task<IActionResult> GetShoppingListsByShopperId(int shopperId)
        {
            var shoppingLists = await _shoppingListService.GetShoppingListsByShopperId(shopperId);

            if (shoppingLists == null || !shoppingLists.Any())
            {
                return NotFound();  // Return 404 if no shopping lists found
            }

            // map each ShoppingList domain model to ShoppingListDTO model
            var shoppingListsDTOs = new List<ShoppingListDTO>();

            foreach (var shoppingList in shoppingLists)
            {
                var shoppingListDTO = await ShoppingListMapperDomainToDTO.MapToDTO(shoppingList, _shopperService, _itemService);
                shoppingListsDTOs.Add(shoppingListDTO);
            }

            return Ok(shoppingListsDTOs); // the list of ShoppingListsDTO objects is returned with a 200 OK response    
        }

        [HttpDelete]
        [Route("deleteShoppingList/{id}")]
        public async Task<IActionResult> DeleteShopping(int id)
        {
            await _shoppingListService.DeleteShoppingList(id);

            return Ok();
        }

        [HttpPost]
        [Route("addShoppingList")]
        public async Task<IActionResult> AddShoppingList([FromBody] ShoppingListDTO shoppingListDTO)   // adding shopping list and shopping list items to database
        {
            if (shoppingListDTO == null || shoppingListDTO.Items == null || !shoppingListDTO.Items.Any()) 
            { 
                return BadRequest("Shopping list and shopping list items can't be null or empty"); 
            }

            // One item can be found in maximum of 3 shopping lists:
            foreach (var shoppingListItem in shoppingListDTO.Items)
            {
                var countOfItemInShoppingList = await _shoppingListService.getCountOfItemInShoppingList(shoppingListItem.Item.Id); 
                if (countOfItemInShoppingList >= 3)
                {
                    return BadRequest($"{shoppingListItem.Item.Name} is already in 3 shopping lists and one item can be found in maximum of 3 shopping lists");
                }
            }

            var shoppingListDomain = await ShoppingListMapperDTOToDomain.MapToDomain(shoppingListDTO, _shopperService, _itemService);  // map dto to domain

            await _shoppingListService.AddShoppingList(shoppingListDomain);  // passing domain to service

            return Ok();
        }
    }
}
