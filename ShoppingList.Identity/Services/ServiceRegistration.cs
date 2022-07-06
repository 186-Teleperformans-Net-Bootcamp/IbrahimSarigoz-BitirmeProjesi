using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Application.Abstractions.Token;
using ShoppingList.Identity.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Identity.Services
{
    public static class ServiceRegistration
    {
        public static void AddIdentityServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
