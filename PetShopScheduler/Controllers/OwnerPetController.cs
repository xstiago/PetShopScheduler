using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetShopScheduler.Controllers
{
    public class OwnerPetController : ApiController
    {
        private IDomainBase<OwnerPet> _ownerPetDomain;

        public OwnerPetController(IDomainBase<OwnerPet> ownerPetDomain)
        {
            _ownerPetDomain = ownerPetDomain;
        }

        [HttpGet]
        public OwnerPet Get(long id)
        {
            return _ownerPetDomain.Get(id);
        }

        [HttpPost]
        public OwnerPet Add(OwnerPet ownerPet)
        {
            return _ownerPetDomain.Add(ownerPet);
        }

        [HttpPost]
        public OwnerPet Update(OwnerPet ownerPet)
        {
            return _ownerPetDomain.Update(ownerPet);
        }
    }
}
