using MediatR;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Commands.CreateShoppingList
{
    public class CreateShoppingListCommandRequest : IRequest<CreateShoppingListCommandResponse>
    {
        public string ListName { get; set; }


        public virtual Category Category { get; set; }
        public bool IsItCompleted { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
