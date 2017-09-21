using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShopScheduler.Domain.Interfaces
{
    public interface IDomainBase<T>
    {
        T Get(long id);
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
