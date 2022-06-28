using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Identity
{
    public class ShoppingListIdentityDbContext : IdentityDbContext<AppUser>
    {
        public ShoppingListIdentityDbContext(DbContextOptions<ShoppingListIdentityDbContext> options): base(options)
        {

        }

    }
}
