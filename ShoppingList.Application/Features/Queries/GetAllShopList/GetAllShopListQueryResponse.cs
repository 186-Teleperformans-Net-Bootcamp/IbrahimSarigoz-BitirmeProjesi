using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Queries.GetAllShopList
{
    public class GetAllShopListQueryResponse
    {
        public int TotalCount { get; set; }
        public object ShopLists { get; set; }


    }
}
