using MediatR;
using ShoppingList.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Commands.RemoveShoppingList
{
    public class RemoveShoppingListCommandHandler : IRequestHandler<RemoveShoppingListCommandRequest, RemoveShoppingListCommandResponse>
    {
        readonly IShopListWriteRepository _shopListWriteRepository;

        public RemoveShoppingListCommandHandler(IShopListWriteRepository shopListWriteRepository)
        {
            _shopListWriteRepository = shopListWriteRepository;
        }

        public async Task<RemoveShoppingListCommandResponse> Handle(RemoveShoppingListCommandRequest request, CancellationToken cancellationToken)
        {
            await _shopListWriteRepository.RemoveAsync(request.Id);
            await _shopListWriteRepository.SaveAsync();

            return new(); 
        }
    }
}
