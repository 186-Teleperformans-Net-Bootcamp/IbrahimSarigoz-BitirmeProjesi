using MediatR;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Commands.AddItemToShopList
{
    public class AddItemToShopListCommandRequest :IRequest<AddItemToShopListCommandResponse>
    {
        public string ShoppingListId { get; set; }

        public string ItemName { get; set; }

        public bool ItemReceived { get; set; } //Has the item been received? 

        public int Amount { get; set; }

        //public Unit Unit { get; set; }

        //Unit i eklediğimde sorun çıkıyor sebebini bulamadım bir türlü 


    }
}
