using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Abstractions;
using ShoppingList.Application.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppinglistsController : ControllerBase
    {
        readonly private IShopListWriteRepository _shopListWriteRepository;
        readonly private IShopListReadRepository _shopListReadRepository;


        public ShoppinglistsController(IShopListWriteRepository shopListWriteRepository, IShopListReadRepository shopListReadRepository)
        {
            _shopListWriteRepository = shopListWriteRepository;
            _shopListReadRepository = shopListReadRepository;
        }


        [HttpGet]

        public async void Get()
        {
            await _shopListWriteRepository.AddRangeAsync(new()
            {
                new() { Id=Guid.NewGuid(),IsItCompleted=false,ListName="Hello" , Category = new Category() { Id = Guid.NewGuid(),CategoryName = " Bilgisayar "  } },
                new() { Id = Guid.NewGuid(), IsItCompleted = false, ListName = "myName", Category = new Category() { Id = Guid.NewGuid(), CategoryName = " Bilgisayar " } },
                new() { Id = Guid.NewGuid(), IsItCompleted = true, ListName = "Is", Category = new Category() { Id = Guid.NewGuid(), CategoryName = " Bilgisayar " } },
                new() { Id = Guid.NewGuid(), IsItCompleted = true, ListName = "ibo", Category = new Category() { Id = Guid.NewGuid(), CategoryName = " Bilgisayar " } }

            });
            await  _shopListWriteRepository.SaveAsync();

        }




        //private readonly IShopListService _shopListService;

        //public ShoppinglistsController(IShopListService shopListService)
        //{
        //    _shopListService = shopListService;
        //}



        //[HttpGet]

        //public IActionResult GetShopLists()
        //{

        //    var shopLists = _shopListService.GetShopLists();

        //    return Ok(shopLists);
        //}





        //[HttpPost]
        //public IActionResult CreateShoppingList([FromBody]  ShopList list)
        //{

        //    return Ok();

        //}


    }
}
