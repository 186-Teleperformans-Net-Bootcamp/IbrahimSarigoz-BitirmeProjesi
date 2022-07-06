using MediatR;
using ShoppingList.Application.Repositories;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Commands.AddItemToShopList
{
    public class AddItemToShopListCommandHandler : IRequestHandler<AddItemToShopListCommandRequest, AddItemToShopListCommandResponse>
    {
        readonly private IShopListReadRepository _shopListReadRepository;
        readonly private IShopListWriteRepository _shopListWriteRepository;


        public AddItemToShopListCommandHandler(IShopListReadRepository shopListReadRepository, IShopListWriteRepository shopListWriteRepository)
        {
            _shopListReadRepository = shopListReadRepository;
            _shopListWriteRepository = shopListWriteRepository;

        }

        public async Task<AddItemToShopListCommandResponse> Handle(AddItemToShopListCommandRequest request, CancellationToken cancellationToken)
        {

            ShopList shopList = await _shopListReadRepository.GetByIdAsync(request.ShoppingListId);
            shopList.Items.Add(new Item() { ItemName = request.ItemName, Amount = request.Amount, ItemReceived = request.ItemReceived });
            
           // Item item = new Item() { Unit =request.Unit,   }

           // shopList.Items.Add(request.Item);

            await _shopListWriteRepository.SaveAsync();

            return new();

        }
            
    }
}
