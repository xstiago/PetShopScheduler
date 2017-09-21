using Ninject.Modules;
using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Domain.Validators;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopScheduler.Domain
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            //VALIDATORS
            Bind<IValidatorBase<Pet>>().To<PetValidator>();
            Bind<IValidatorBase<Breed>>().To<BreedValidator>();
            Bind<IDocumentValidator>().To<CpfValidator>();
            Bind<IValidatorBase<OwnerPet>>().To<OwnerPetValidator>();
            Bind<IValidatorBase<Establishment>>().To<EstablishmentValidator>();

            //DOMAINS
            Bind<IDomainBase<Pet>>().To<PetDomain>();
            Bind<IDomainBase<Breed>>().To<BreedDomain>();
            Bind<IDomainBase<OwnerPet>>().To<OwnerPetDomain>();
            Bind<IDomainBase<Establishment>>().To<EstablishmentDomain>();
            Bind<IDomainBase<Schedule>>().To<ScheduleDomain>();
        }
    }
}
