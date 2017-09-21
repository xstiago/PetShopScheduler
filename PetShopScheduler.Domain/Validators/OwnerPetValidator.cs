using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Validators
{
    public class OwnerPetValidator : IValidatorBase<OwnerPet>
    {
        private IDocumentValidator _documentValidator;

        public OwnerPetValidator(IDocumentValidator documentValidator)
        {
            _documentValidator = documentValidator;
        }
        
        public void ValidateEntity(OwnerPet entity)
        {
            if (entity != null)
            {
                ValidateName(entity);
                ValidateDocument(entity);
                ValidateAddress(entity);
                ValidateNumberFone(entity);
            }
        }

        private void ValidateNumberFone(OwnerPet entity)
        {
            if (string.IsNullOrWhiteSpace(entity.FoneNumber1))
                throw new OwnerPetValidatorException();
        }

        private void ValidateAddress(OwnerPet entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Address))
                throw new OwnerPetValidatorException(Properties.Resources.OwnerPetAddressError);

            if(string.IsNullOrWhiteSpace(entity.AddressNumber))
                throw new OwnerPetValidatorException(Properties.Resources.OwnerPetAddressNumberError);

            if(string.IsNullOrWhiteSpace(entity.District))
                throw new OwnerPetValidatorException(Properties.Resources.OwnerPetDistrictError);

            if(string.IsNullOrWhiteSpace(entity.ZipCode))
                throw new OwnerPetValidatorException(Properties.Resources.OwnerPetZipCodeError);

            if(entity.City == null)
                throw new OwnerPetValidatorException(Properties.Resources.OwnerPetCityError);

            if(entity.State == null)
                throw new OwnerPetValidatorException(Properties.Resources.OwnerPetStateError);
        }

        private void ValidateDocument(OwnerPet entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Document))
                throw new OwnerPetValidatorException(Properties.Resources.OwnerPetDocumentError);

            if(_documentValidator.Validate(entity.Document))
                throw new OwnerPetValidatorException(Properties.Resources.OwnerPetDocumentInvalidError);
        }

        private void ValidateName(OwnerPet entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new OwnerPetValidatorException(Properties.Resources.OwnerPetNameError);
        }
    }
}
