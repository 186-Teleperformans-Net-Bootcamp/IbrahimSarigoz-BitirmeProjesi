using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Features.Queries.GetByIdShopList
{
    public class GetByIdShopListQueryResponse
    {
        public string ListName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime CompletionDate { get; set; }
        public virtual Category Category { get; set; }
        public bool IsItCompleted { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
