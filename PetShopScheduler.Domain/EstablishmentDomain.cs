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
    public class EstablishmentDomain : IDomainBase<Establishment>
    {
        private IValidatorBase<Establishment> _establishmentValidator;
        private IRepository<Establishment> _establishmentRepository;
        
        public EstablishmentDomain(IValidatorBase<Establishment> establishmentValidator, IRepository<Establishment> establishmentRepository)
        {
            _establishmentValidator = establishmentValidator;
            _establishmentRepository = establishmentRepository;
        }
        
        public void Add(Establishment entity)
        {
            _establishmentValidator.ValidateEntity(entity);
            _establishmentRepository.Insert(entity);
        }

        public Establishment Get(long id)
        {
            return _establishmentRepository.Get(id);
        }

        public IEnumerable<Establishment> Get(Expression<Func<Establishment, bool>> expression)
        {
            return _establishmentRepository.Get(expression);
        }

        public void Update(Establishment entity)
        {
            _establishmentValidator.ValidateEntity(entity);
            _establishmentRepository.Update(entity);
        }

        public void Delete(Establishment entity)
        {
            _establishmentRepository.Delete(entity);
        }
    }
}
