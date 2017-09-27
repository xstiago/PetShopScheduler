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
    public class OwnerPetDomain : IDomainBase<OwnerPet>
    {
        private IValidatorBase<OwnerPet> _ownerPetValidator;
        private IRepository<OwnerPet> _ownerPetRepository;

        public OwnerPetDomain(IValidatorBase<OwnerPet> ownerPetValidator, IRepository<OwnerPet> ownerPetRepository)
        {
            _ownerPetValidator = ownerPetValidator;
            _ownerPetRepository = ownerPetRepository;
        }

        public OwnerPet Add(OwnerPet entity)
        {
            _ownerPetValidator.ValidateEntity(entity);
            _ownerPetRepository.Insert(entity);

            return entity;
        }

        public OwnerPet Get(long id)
        {
            return _ownerPetRepository.Get(id);
        }

        public IEnumerable<OwnerPet> Get(Expression<Func<OwnerPet, bool>> expression)
        {
            return _ownerPetRepository.Get(expression);
        }

        public OwnerPet Update(OwnerPet entity)
        {
            _ownerPetValidator.ValidateEntity(entity);
            _ownerPetRepository.Update(entity);

            return entity;
        }

        public OwnerPet Delete(OwnerPet entity)
        {
            _ownerPetRepository.Delete(entity);
            return entity;
        }
    }
}
