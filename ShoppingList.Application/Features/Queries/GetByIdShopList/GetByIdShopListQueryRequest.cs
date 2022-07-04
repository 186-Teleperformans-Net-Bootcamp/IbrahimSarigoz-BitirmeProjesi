using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Queries.GetByIdShopList
{
    public class GetByIdShopListQueryRequest : IRequest<GetByIdShopListQueryResponse>
    {

        public string Id { get; set; }
    }
}
