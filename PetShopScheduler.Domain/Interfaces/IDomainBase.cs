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
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
