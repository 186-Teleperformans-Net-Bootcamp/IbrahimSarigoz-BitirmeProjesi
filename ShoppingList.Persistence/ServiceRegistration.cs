using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Application.Abstractions;
using ShoppingList.Persistence.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Persistence.Contexts;
using Microsoft.Extensions.Configuration;

namespace ShoppingList.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistanceServices(this IServiceCollection services )
        {
            

            services.AddSingleton<IShopListService, ShopListService>();


            services.AddDbContext<ShoppingListDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));



        }
    }
}
