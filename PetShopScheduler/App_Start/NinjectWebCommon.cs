[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PetShopScheduler.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PetShopScheduler.App_Start.NinjectWebCommon), "Stop")]

namespace PetShopScheduler.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using PetShopScheduler.Entities;
    using PetShopScheduler.Domain.Interfaces;
    using PetShopScheduler.Domain;
    using PetShopScheduler.Domain.Validators;
    using PetShopScheduler.DataAccess;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDomainBase<Pet>>().To<PetDomain>();
            kernel.Bind<IDomainBase<Breed>>().To<BreedDomain>();
            kernel.Bind<IDomainBase<OwnerPet>>().To<OwnerPetDomain>();
            kernel.Bind<IDomainBase<Establishment>>().To<EstablishmentDomain>();
            kernel.Bind<IDomainBase<Schedule>>().To<ScheduleDomain>();

            kernel.Bind<IValidatorBase<Pet>>().To<PetValidator>();
            kernel.Bind<IValidatorBase<Breed>>().To<BreedValidator>();
            kernel.Bind<IValidatorBase<OwnerPet>>().To<OwnerPetValidator>();
            kernel.Bind<IValidatorBase<Establishment>>().To<EstablishmentValidator>();
            kernel.Bind<IValidatorBase<Schedule>>().To<ScheduleValidator>();
        }        
    }
}
