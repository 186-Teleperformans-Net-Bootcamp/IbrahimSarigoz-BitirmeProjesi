using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Persistence.Contexts
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShopList> ShopLists { get; set; }

        //burda her yeni entity oluştuğunda ona id atmak için yapıyorum.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //yapılan değişiklikleri yakalıyorum.
            var items = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in items)
            {
                //artık add fonksiyonu her çağırıldığımda yeni bir id ekliyor otomatik 
                if (EntityState.Added==item.State )
                {
                    item.Entity.Id = Guid.NewGuid();

                }
             
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
