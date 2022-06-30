﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingList.Application.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        readonly private ShoppingListDbContext _context;

        public WriteRepository(ShoppingListDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entryEntity = await Table.AddAsync(model);

            return entryEntity.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);

            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entryEntity = Table.Remove(model);

            return entryEntity.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

            return Remove(model);
        }



        public bool Update(T model)
        {
            EntityEntry entityEntry=  Table.Update(model);

            return entityEntry.State == EntityState.Modified;
        }


        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();



    }
}