using ShoppingList.Application.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Persistence.Repositories
{
    public class ShopListReadRepository : ReadRepository<ShopList>, IShopListReadRepository
    {
        public ShopListReadRepository(ShoppingListDbContext context) : base(context)
        {
        }
    }
}
