using Microsoft.EntityFrameworkCore;
using ShoppingList.Application.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ShoppingListDbContext _context; // IoC Containerden geliyor!!!!
        public ReadRepository(ShoppingListDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table; // Dbset zaten IQuaryable bu yüzden table direkt olarak döndürülebilir.


        public async Task<T> GetByIdAsync(string id) //where t yi class deseydim id ye erişemezdim ama alanı daraltıp BaseEntity e çekerek id ye erişebildim. Bu sayede reflection yapmama gerek kalmadı. 
        {
           return await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
            =>await Table.FirstOrDefaultAsync(expression);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
            => Table.Where(expression);
    }
}
