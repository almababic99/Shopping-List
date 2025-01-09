using Microsoft.AspNetCore.Mvc;
using Application.DTOModels;
using Application.Interfaces;

namespace API.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ShopperController : ControllerBase
    {
        private readonly IShopperService _shopperService;

        public ShopperController(IShopperService shopperInterface)  // Constructor for Dependency Injection of IShopperRepository
        {
            _shopperService = shopperInterface;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Fetch shoppers from the repository
            var shoppers = await _shopperService.GetShoppers();

            // Check if the result is null or empty and return appropriate response
            if (shoppers == null || !shoppers.Any())
            {
                return NotFound();  // Return 404 if no shoppers found
            }

            return Ok(shoppers.Select(a => new ShopperDTO
            {
                Id = a.Id,
                Name = a.Name,
            }).ToList());  
        }
    }
}
