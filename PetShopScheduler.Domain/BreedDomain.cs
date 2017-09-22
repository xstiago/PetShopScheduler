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
    public class BreedDomain : IDomainBase<Breed>
    {
        private IValidatorBase<Breed> _breedValidator;
        private IRepository<Breed> _breedRepository;
        
        public BreedDomain(IValidatorBase<Breed> breedValidator, IRepository<Breed> breedRepository)
        {
            _breedValidator = breedValidator;
            _breedRepository = breedRepository;
        }

        public void Add(Breed entity)
        {
            _breedValidator.ValidateEntity(entity);
            _breedRepository.Insert(entity);
        }

        public Breed Get(long id)
        {
            return _breedRepository.Get(id);
        }

        public IEnumerable<Breed> Get(Expression<Func<Breed, bool>> expression)
        {
            return _breedRepository.Get(expression);
        }

        public void Update(Breed entity)
        {
            _breedValidator.ValidateEntity(entity);
            _breedRepository.Update(entity);
        }

        public void Delete(Breed entity)
        {
            _breedRepository.Delete(entity);
        }
    }
}
