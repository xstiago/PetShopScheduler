﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace PetShopScheduler.App_Start
{
    public class LocalNinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public LocalNinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
        }
    }
}