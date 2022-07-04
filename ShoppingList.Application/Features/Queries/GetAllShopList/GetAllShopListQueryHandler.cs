using MediatR;
using ShoppingList.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Queries.GetAllShopList
{
    public class GetAllShopListQueryHandler : IRequestHandler<GetAllShopListQueryRequest, GetAllShopListQueryResponse>
    {
        readonly private IShopListReadRepository _shopListReadRepository;

        public GetAllShopListQueryHandler(IShopListReadRepository shopListReadRepository)
        {
            _shopListReadRepository = shopListReadRepository;
        }

       
        public async Task<GetAllShopListQueryResponse> Handle(GetAllShopListQueryRequest request, CancellationToken cancellationToken)
        {


            // client ayrıca totalcountuda bilmeli 
            var totalCount = _shopListReadRepository.GetAll(false).Count();


            var shopLists = _shopListReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new
            {
                p.Id,
                p.ListName,
                p.IsItCompleted,
                p.Items,
                p.Category,
                p.CreationDate

            }).ToList();

            return new() {

                ShopLists = shopLists,

                TotalCount = totalCount
            };

           
        }
    }
}
