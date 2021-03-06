using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Commands.RemoveShoppingList
{
    public class RemoveShoppingListCommandRequest:IRequest<RemoveShoppingListCommandResponse>
    {

        public string Id { get; set; } 
    }
}
