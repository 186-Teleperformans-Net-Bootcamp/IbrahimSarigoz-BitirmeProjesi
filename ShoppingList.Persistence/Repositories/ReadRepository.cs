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


        //tracking eklememin sebebi veri üzerinde değişiklik yapmayacağım zaman maliyeti düşürmek için 
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;

        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.Where(expression);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;


        }


        public async Task<T> GetByIdAsync(string id, bool tracking = true) //where t yi class deseydim id ye erişemezdim ama alanı daraltıp BaseEntity e çekerek id ye erişebildim. Bu sayede reflection yapmama gerek kalmadı. 
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            

            return await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

            //return await Table.FindAsync(Guid.Parse(id));

        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(expression);

        }



     
    }
}
