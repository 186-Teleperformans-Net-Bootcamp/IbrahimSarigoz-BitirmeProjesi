using MediatR;
using ShoppingList.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Commands.CreateShoppingList
{
    public class CreateShoppingListCommandHandler : IRequestHandler<CreateShoppingListCommandRequest, CreateShoppingListCommandResponse>
    {

        readonly  IShopListWriteRepository _shopListWriteRepository;
        public CreateShoppingListCommandHandler(IShopListWriteRepository shopListWriteRepository)
        {
            _shopListWriteRepository = shopListWriteRepository;
        }

        public async Task<CreateShoppingListCommandResponse> Handle(CreateShoppingListCommandRequest request, CancellationToken cancellationToken)
        {
            await _shopListWriteRepository.AddAsync(new()
            {
                CreationDate = DateTime.Now,
                Category = request.Category,
                IsItCompleted = request.IsItCompleted,
                Items = request.Items,
                ListName = request.ListName
            });
            await _shopListWriteRepository.SaveAsync();

            return new();
        }
    }
}
