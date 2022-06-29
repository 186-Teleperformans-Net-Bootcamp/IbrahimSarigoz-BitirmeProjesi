using ShoppingList.Application.Abstractions;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Persistence.Concretes
{
    public class ShopListService : IShopListService
    {
        public List<ShopList> GetShopLists()
            => new() {
                new() { Id = Guid.NewGuid(),Category = new() { CategoryName = "market alışverişi" ,Id = Guid.NewGuid()} ,IsItCompleted =false , ListName ="My List" },
                new() { Id = Guid.NewGuid(), Category = new() { CategoryName = "market alışverişi2", Id = Guid.NewGuid() }, IsItCompleted = false, ListName = "My List2" },
                new() { Id = Guid.NewGuid(), Category = new() { CategoryName = "market alışverişi3", Id = Guid.NewGuid() }, IsItCompleted = false, ListName = "My List23" }


            };
    }
}
