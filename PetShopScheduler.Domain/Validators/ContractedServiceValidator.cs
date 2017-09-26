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
    public class ContractedServiceValidator : IValidatorBase<ContractedService>
    {
        public void ValidateEntity(ContractedService entity)
        {
            if (entity == null)
                throw new ContractedServiceValidatorException();

            if (entity.Value <= 0)
                throw new ContractedServiceValidatorException();
        }
    }
}
