using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.ViewModels.ShopLists
{
    public class VM_Update_ShopList
    {
        public string Id { get; set; }

        public string ListName { get; set; }


        public virtual Category Category { get; set; }
        public bool IsItCompleted { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
