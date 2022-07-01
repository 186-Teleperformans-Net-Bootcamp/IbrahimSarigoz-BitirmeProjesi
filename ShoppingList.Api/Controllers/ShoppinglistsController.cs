using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Abstractions;
using ShoppingList.Application.Repositories;
using ShoppingList.Application.ViewModels.ShopLists;
using ShoppingList.Domain.Entities;
using System.Net;

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
        public async Task<IActionResult> Get()
        {
            return Ok(_shopListReadRepository.GetAll());

        }



        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            ShopList shopList = await _shopListReadRepository.GetByIdAsync(id);

            return Ok(shopList);


        }



        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_ShopList model)
        {
            await _shopListWriteRepository.AddAsync(new()
            {
                CreationDate = DateTime.Now,
                Category = model.Category,
                IsItCompleted = model.IsItCompleted,
                Items = model.Items,
                ListName = model.ListName
            });
            await _shopListWriteRepository.SaveAsync();

            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpPut]


        public async Task<IActionResult> Put(VM_Update_ShopList model)
        {
            ShopList shopList = await _shopListReadRepository.GetByIdAsync(model.Id);

            shopList.Items = model.Items;
            shopList.ListName = model.ListName;
            shopList.IsItCompleted = model.IsItCompleted;
            shopList.Category = model.Category;

            await _shopListWriteRepository.SaveAsync();

            return Ok();
        }





        //bu id de list yoksa ne döneceğim onuda düşünmeliyim burda

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _shopListWriteRepository.RemoveAsync(id);
            await _shopListWriteRepository.SaveAsync();


            return Ok();
        }



    }
}
