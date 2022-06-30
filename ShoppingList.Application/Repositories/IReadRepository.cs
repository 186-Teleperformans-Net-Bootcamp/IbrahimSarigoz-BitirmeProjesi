using ShoppingList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Repositories
{
    public interface IReadRepository <T>: IRepository<T>  where T:BaseEntity
    {
        // sorguda çalıştığım için Iqueryable diyorum. 
        IQueryable<T> GetAll(bool tracking = true); 

        IQueryable<T> GetWhere(Expression<Func<T,bool>> expression, bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true); // Async çalıştığı için datamızı Task olarak döndürdük. 

        Task<T> GetByIdAsync(string id, bool tracking = true); // ORM de Async çalıştıkları için böyle kodladım. 

    }
}
