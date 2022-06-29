using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {

            get
            {
                ConfigurationManager configuration = new();
                configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../ShoppingList/ShoppingList.Api"));
                configuration.AddJsonFile("appsettings.json");

                return configuration.GetConnectionString("Sql");
            }
        }

    }
}
