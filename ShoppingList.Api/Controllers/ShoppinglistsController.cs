using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Abstractions;
using ShoppingList.Application.Features.Commands.AddItemToShopList;
using ShoppingList.Application.Features.Commands.CreateShoppingList;
using ShoppingList.Application.Features.Commands.RemoveShoppingList;
using ShoppingList.Application.Features.Commands.UpdateShoppingList;
using ShoppingList.Application.Features.Queries.GetAllShopList;
using ShoppingList.Application.Features.Queries.GetByIdShopList;
using ShoppingList.Application.Repositories;
using ShoppingList.Application.RequestParamaters;

using ShoppingList.Domain.Entities;
using System.Net;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ShoppinglistsController : ControllerBase
    {
        readonly private IShopListWriteRepository _shopListWriteRepository;
        readonly private IShopListReadRepository _shopListReadRepository;

        readonly IMediator _mediator;
        public ShoppinglistsController(IShopListWriteRepository shopListWriteRepository, IShopListReadRepository shopListReadRepository, IMediator mediator)
        {
            _shopListWriteRepository = shopListWriteRepository;
            _shopListReadRepository = shopListReadRepository;
            _mediator = mediator;
        }


        [HttpGet]
        
        public async Task<IActionResult> Get([FromQuery] GetAllShopListQueryRequest getAllShopListQueryRequest)
        {
            GetAllShopListQueryResponse response = await _mediator.Send(getAllShopListQueryRequest);

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateShoppingListCommandRequest request)
        {
            await _mediator.Send(request);

            return StatusCode((int)HttpStatusCode.Created);
        }



        [HttpGet("{Id}")]
        [ResponseCache(Duration = 600,VaryByQueryKeys = new string [] {"Id"})]
        public async Task<IActionResult> Get([FromRoute] GetByIdShopListQueryRequest request)
        {
            GetByIdShopListQueryResponse response = await _mediator.Send(request);
            return Ok(response);

        }


        [HttpPost("AddItem")]

        public async Task<IActionResult> Put([FromBody] AddItemToShopListCommandRequest request)
        {
            await _mediator.Send(request);



            //await _shopListWriteRepository.SaveAsync();


            return Ok();


        }

        [HttpPut]

        public async Task<IActionResult> Put([FromBody] UpdateShoppingListCommandRequest request)
        {

            UpdateShoppingListCommandResponse response = await _mediator.Send(request);

            return Ok();
        }

        //bu id de list yoksa ne döneceğim onuda düşünmeliyim burda

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveShoppingListCommandRequest request)
        {

            RemoveShoppingListCommandResponse response = await _mediator.Send(request);

            return Ok();
        }



    }
}
