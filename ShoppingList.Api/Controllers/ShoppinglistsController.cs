using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppinglistsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateShoppingList([FromBody]  ShopList list)
        {

            return Ok();

        }


    }
}
