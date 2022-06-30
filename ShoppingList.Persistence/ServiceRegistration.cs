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
using ShoppingList.Application.Repositories;
using ShoppingList.Persistence.Repositories;

namespace ShoppingList.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistanceServices(this IServiceCollection services )
        {
            services.AddDbContext<ShoppingListDbContext>(options => options.UseSqlServer(Configuration.ConnectionString),ServiceLifetime.Singleton);

            services.AddSingleton<IShopListService, ShopListService>();
           
            services.AddSingleton<ICategoryReadRepository, CategoryReadRepository>();
            services.AddSingleton<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddSingleton<IItemReadRepository, ItemReadRepository>();
            services.AddSingleton<IItemWriteRepository, ItemWriteRepository>();

            services.AddSingleton<IShopListReadRepository, ShopListReadRepository>();
            services.AddSingleton<IShopListWriteRepository, ShopListWriteRepository>();


            



        }
    }
}
