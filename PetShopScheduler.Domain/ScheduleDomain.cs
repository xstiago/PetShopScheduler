using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShopScheduler.Domain
{
    public class ScheduleDomain : IDomainBase<Schedule>
    {
        public Schedule Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Schedule> Get(Expression<Func<Schedule, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Add(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Schedule entity)
        {
            throw new NotImplementedException();
        }
    }
}
