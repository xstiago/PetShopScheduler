using PetShopScheduler.Domain.Exceptions;
using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopScheduler.Domain.Validators
{
    public class PetValidator : IValidatorBase<Pet>
    {
        private IValidatorBase<Breed> _breedValidator;
        private IValidatorBase<OwnerPet> _ownerPetValidator;

        public PetValidator(IValidatorBase<Breed> breedValidator, IValidatorBase<OwnerPet> ownerPetValidator)
        {
            _breedValidator = breedValidator;
            _ownerPetValidator = ownerPetValidator;
        }
        
        public void ValidateEntity(Pet entity)
        {
            if (entity != null)
            {
                ValidateName(entity);
                ValidateBirthDate(entity);
                ValidateWeigth(entity);

                if (entity.Breed != null)
                    _breedValidator.ValidateEntity(entity.Breed);
                else
                    throw new PetValidatorException(Properties.Resources.PetBreedError);

                if (entity.OwnerPet != null)
                    _ownerPetValidator.ValidateEntity(entity.OwnerPet);
                else
                    throw new PetValidatorException(Properties.Resources.PetNeedOwnerError);
            }
        }

        private void ValidateName(Pet entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new PetValidatorException(Properties.Resources.PetNameError);
        }

        private void ValidateBirthDate(Pet entity)
        {
            if (entity.BirthDate.Date >= DateTime.Now.Date)
                throw new PetValidatorException(Properties.Resources.PetBirthDateError);
        }

        private void ValidateWeigth(Pet entity)
        {
            if (entity.Weigth < 0)
                throw new PetValidatorException(Properties.Resources.PetWeigthError);
        }
    }
}
