using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain.Entities
{
    public class ShoppingList:BaseEntity
    {
        public string ListName { get; set; }

        public Category Category { get; set; }


        public bool IsItCompleted { get; set; }

        public List<Item> Items { get; set; }

    }
}
