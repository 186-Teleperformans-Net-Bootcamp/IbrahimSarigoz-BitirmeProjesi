using MediatR;
using ShoppingList.Application.Repositories;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Commands.UpdateShoppingList
{
    public class UpdateShoppingListCommandHandler : IRequestHandler<UpdateShoppingListCommandRequest, UpdateShoppingListCommandResponse>
    {
        readonly private IShopListReadRepository _shopListReadRepository;
        readonly private IShopListWriteRepository _shopListWriteRepository;


        public UpdateShoppingListCommandHandler(IShopListReadRepository shopListReadRepository, IShopListWriteRepository shopListWriteRepository)
        {
            _shopListReadRepository = shopListReadRepository;
            _shopListWriteRepository = shopListWriteRepository;

        }


        public async Task<UpdateShoppingListCommandResponse> Handle(UpdateShoppingListCommandRequest request, CancellationToken cancellationToken)
        {

            ShopList shopList = await _shopListReadRepository.GetByIdAsync(request.Id);

            shopList.Items = request.Items;
            shopList.ListName = request.ListName;
            shopList.IsItCompleted = request.IsItCompleted;
            shopList.Category = request.Category;

            await _shopListWriteRepository.SaveAsync();

            return new();
        }
    }
}
