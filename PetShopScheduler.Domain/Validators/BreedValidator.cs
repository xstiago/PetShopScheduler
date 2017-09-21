using PetShopScheduler.Domain.Exceptions;
using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Validators
{
    public class BreedValidator : IValidatorBase<Breed>
    {
        public void ValidateEntity(Breed entity)
        {
            if (entity != null)
            {
                ValidateDescription(entity);
            }
        }

        private void ValidateDescription(Breed entity)
        {
            if(string.IsNullOrWhiteSpace(entity.Description))
                throw new BreedValidatorException(Properties.Resources.BreedDescriptionError);
        }
    }
}
