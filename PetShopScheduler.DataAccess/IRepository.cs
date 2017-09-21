using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShopScheduler.DataAccess
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(object id);
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }  
}
