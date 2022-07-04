using MediatR;
using ShoppingList.Application.RequestParamaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Queries.GetAllShopList
{
    public class GetAllShopListQueryRequest : IRequest<GetAllShopListQueryResponse>
    {
        //public Pagination Pagination { get; set; }

        public int Page { get; set; } = 0;

        public int Size { get; set; } = 5; //Default değerler girdim 

    }
}
