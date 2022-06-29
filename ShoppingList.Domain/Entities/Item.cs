using ShoppingList.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain.Entities
{
    public class Item:BaseEntity
    {
        public string ItemName { get; set; }

        public bool ItemReceived { get; set; } //Has the item been received? 

        public int Amount { get; set; }

        public Unit Unit { get; set; }

    }
}
