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
            services.AddDbContext<ShoppingListDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
                options.UseLazyLoadingProxies();
                
                
                });

            services.AddSingleton<IShopListService, ShopListService>();
           
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IItemReadRepository, ItemReadRepository>();
            services.AddScoped<IItemWriteRepository, ItemWriteRepository>();

            services.AddScoped<IShopListReadRepository, ShopListReadRepository>();
            services.AddScoped<IShopListWriteRepository, ShopListWriteRepository>();


            



        }
    }
}
