using PetShopScheduler.DataAccess;
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
        private IValidatorBase<Schedule> _scheduleValidator;
        private IRepository<Schedule> _scheduleRepository;

        public ScheduleDomain(IValidatorBase<Schedule> scheduleValidator, IRepository<Schedule> scheduleRepository)
        {
            _scheduleValidator = scheduleValidator;
            _scheduleRepository = scheduleRepository;
        }
        
        public Schedule Get(long id)
        {
            return _scheduleRepository.Get(id);
        }

        public IEnumerable<Schedule> Get(Expression<Func<Schedule, bool>> expression)
        {
            return _scheduleRepository.Get(expression);
        }

        public void Add(Schedule entity)
        {
            _scheduleValidator.ValidateEntity(entity);
            _scheduleRepository.Insert(entity);
        }

        public void Update(Schedule entity)
        {
            _scheduleValidator.ValidateEntity(entity);
            _scheduleRepository.Update(entity);
        }

        public void Delete(Schedule entity)
        {
            _scheduleRepository.Delete(entity);
        }
    }
}
