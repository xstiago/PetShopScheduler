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
    public class PetDomain : IDomainBase<Pet>
    {
        private IValidatorBase<Pet> _petValidator;
        private IRepository<Pet> _petRepository;

        public PetDomain(IValidatorBase<Pet> petValidator, IRepository<Pet> petRepository)
        {
            _petValidator = petValidator;
            _petRepository = petRepository;
        }
        
        public void Add(Pet entity)
        {
            _petValidator.ValidateEntity(entity);
            _petRepository.Insert(entity);
        }

        public Pet Get(long id)
        {
            return _petRepository.Get(id);
        }

        public IEnumerable<Pet> Get(Expression<Func<Pet, bool>> expression)
        {
            return _petRepository.Get(expression);
        }

        public void Update(Pet entity)
        {
            _petValidator.ValidateEntity(entity);
            _petRepository.Update(entity);
        }

        public void Delete(Pet entity)
        {
            _petRepository.Delete(entity);
        }
    }
}
