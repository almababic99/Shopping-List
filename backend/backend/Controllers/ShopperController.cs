using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using API.Mappers;
using API.DTOModels;

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
        [Route("shoppers")]
        public async Task<IActionResult> Get()   // The Get() method uses the _shopperService.GetShoppers() method to fetch the list of shoppers. This is an asynchronous operation, so it uses await to wait for the result.
        {
            var shoppers = await _shopperService.GetShoppers();

            if (shoppers == null || !shoppers.Any())
            {
                return NotFound();  // Return 404 if no shoppers found
            }

            // map each Shopper domain model to ShopperDTO model
            var shopperDTOs = shoppers.Select(shopper => ShopperMapperDomainToDTO.MapToDTO(shopper)).ToList();

            return Ok(shopperDTOs); // the list of ShopperDTO objects is returned with a 200 OK response            
        }

        [HttpGet]
        [Route("shopper/{id}")]
        public async Task<IActionResult> GetShopperById(int id)
        {
            var shopper = await _shopperService.GetShopperById(id);

            if (shopper == null)
            {
                return NotFound();
            }

            return Ok(shopper);
        }

        [HttpPost]
        [Route("addShopper")]
        public async Task<IActionResult> AddShopper([FromBody] ShopperDTO shopperDTO)
        {
            if (shopperDTO == null)
            {
                return BadRequest("Shopper data is null");
            }

            var shopper = ShopperMapperDTOToDomain.MapToDomain(shopperDTO);  // mapping dto to domain and passing it to service

            await _shopperService.AddShopper(shopper);   // passing domain to service

            return Ok();
        }

        [HttpDelete]
        [Route("deleteShopper/{id}")]
        public async Task<IActionResult> DeleteShopper(int id)
        {
            await _shopperService.DeleteShopper(id);

            return Ok();
        }

        [HttpPut]
        [Route("editShopper/{id}")]

        public async Task<IActionResult> EditShopper(int id, [FromBody] ShopperDTO shopperDTO)
        {
            if (id != shopperDTO.Id)
            {
                return BadRequest();
            }

            var shopper = ShopperMapperDTOToDomain.MapToDomain(shopperDTO);  // mapping dto to domain and passing it to service

            await _shopperService.EditShopper(shopper);  // passing domain to service

            return Ok();
        }
    }
}
