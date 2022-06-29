using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Abstractions;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppinglistsController : ControllerBase
    {

        private readonly IShopListService _shopListService;

        public ShoppinglistsController(IShopListService shopListService)
        {
            _shopListService = shopListService;
        }



        [HttpGet]

        public IActionResult GetShopLists()
        {

            var shopLists = _shopListService.GetShopLists();

            return Ok(shopLists);
        }





        [HttpPost]
        public IActionResult CreateShoppingList([FromBody]  ShopList list)
        {

            return Ok();

        }


    }
}
