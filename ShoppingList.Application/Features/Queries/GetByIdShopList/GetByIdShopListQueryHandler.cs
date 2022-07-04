using MediatR;
using ShoppingList.Application.Repositories;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Queries.GetByIdShopList
{
    public class GetByIdShopListQueryHandler : IRequestHandler<GetByIdShopListQueryRequest, GetByIdShopListQueryResponse>
    {

        readonly IShopListReadRepository _shopListReadRepository;

        public GetByIdShopListQueryHandler(IShopListReadRepository shopListReadRepository)
        {
            _shopListReadRepository = shopListReadRepository; 
        }


        public async Task<GetByIdShopListQueryResponse> Handle(GetByIdShopListQueryRequest request, CancellationToken cancellationToken)
        {
            ShopList shopList = await _shopListReadRepository.GetByIdAsync(request.Id);

            return new() { Category = shopList.Category,
            CompletionDate = shopList.CompletionDate,
            CreationDate= shopList.CreationDate,
            IsItCompleted = shopList.IsItCompleted,
            ListName = shopList.ListName,
            Items = shopList.Items}; 
        }
    }
}
