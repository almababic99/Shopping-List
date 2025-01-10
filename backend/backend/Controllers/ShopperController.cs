using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using API.Mappers;
using Domain.DomainModels;

namespace API.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]  // route for this controller will be /api/shopper
    public class ShopperController : ControllerBase
    {
        private readonly IShopperService _shopperService;

        public ShopperController(IShopperService shopperService)  // Constructor for Dependency Injection of IShopperService
        {
            _shopperService = shopperService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()   // The Get() method uses the _shopperService.GetShoppers() method to fetch the list of shoppers. This is an asynchronous operation, so it uses await to wait for the result.
        {
            var shoppers = await _shopperService.GetShoppers();

            // Check if the result is null or empty and return appropriate response
            if (shoppers == null || !shoppers.Any())
            {
                return NotFound();  // Return 404 if no shoppers found
            }

            // Using ShopperMapper from API.Mappers to map each Shopper domain model to ShopperDTO model
            var shopperDTOs = shoppers.Select(shopperDomain => ShopperMapperDomainToDTO.MapToDTO(shopperDomain)).ToList();

            return Ok(shopperDTOs); // the list of ShopperDTO objects is returned with a 200 OK response            
        }
    }
}
