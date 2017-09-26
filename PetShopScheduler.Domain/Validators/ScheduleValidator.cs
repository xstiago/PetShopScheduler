using PetShopScheduler.Domain.Exceptions;
using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Validators
{
    public class ScheduleValidator : IValidatorBase<Schedule>
    {
        private IValidatorBase<ContractedService> _contractedServiceValidator;
        private IValidatorBase<Establishment> _establishmentValidator;
        private IValidatorBase<Pet> _petValidator;

        public ScheduleValidator(
            IValidatorBase<ContractedService> contractedServiceValidator,
            IValidatorBase<Establishment> establishmentValidator,
            IValidatorBase<Pet> petValidator)
        {
            _contractedServiceValidator = contractedServiceValidator;
            _establishmentValidator = establishmentValidator;
            _petValidator = petValidator;
        }

        public void ValidateEntity(Schedule entity)
        {
            if (entity == null)
                throw new ScheduleValidatorException();

            if (entity.ContractedService == null)
                throw new ScheduleValidatorException();

            if (entity.DateToDo < DateTime.Now)
                throw new ScheduleValidatorException();

            if (entity.Duration < TimeSpan.MinValue)
                throw new ScheduleValidatorException();

            if (entity.Establishment == null)
                throw new ScheduleValidatorException();

            if (entity.Pet == null)
                throw new ScheduleValidatorException();

            if (entity.ServiceValue <= 0)
                throw new ScheduleValidatorException();

            _contractedServiceValidator.ValidateEntity(entity.ContractedService);
            _establishmentValidator.ValidateEntity(entity.Establishment);
            _petValidator.ValidateEntity(entity.Pet);
        }
    }
}
