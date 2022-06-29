using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Abstractions
{
    public interface IShopListService
    {
        List<ShopList> GetShopLists();
    }
}
