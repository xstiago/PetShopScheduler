using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShopScheduler.Domain.Exceptions;
using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Domain.Validators;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopScheduler.Tests.Validators
{
    [TestClass]
    public class EstablishmentValidatorTest
    {
        private IValidatorBase<Establishment> _validator;
        private Establishment _establishment;

        [TestInitialize]
        public void Initialize()
        {
            _validator = new EstablishmentValidator(new CnpjValidator());
            _establishment = new Establishment();
        }
        
        [TestMethod]
        [ExpectedException(typeof(EstablishmentValidatorException))]
        public void EstablishmentToValidateIsNullTest()
        {
            _validator.ValidateEntity(null);
        }

        [TestMethod]
        [ExpectedException(typeof(EstablishmentValidatorException))]
        public void CnpjAtEstablishmentIsInvalidTest()
        {
            _establishment.Name = "EstablishmentName";
            _establishment.Description = "EstablishmentDescription";
            _establishment.Document = "82356203000181";

            _validator.ValidateEntity(_establishment);
        }

        [TestMethod]
        public void CnpjAtEstablishmentIsValidTest()
        {
            _establishment.Name = "EstablishmentName";
            _establishment.Description = "EstablishmentDescription";
            _establishment.Document = "82356203000180";

            _validator.ValidateEntity(_establishment);
        }

        [TestMethod]
        public void CnpjAtEstablishmentIsValidWithSpecialCharsTest()
        {
            _establishment.Name = "EstablishmentName";
            _establishment.Description = "EstablishmentDescription";
            _establishment.Document = "82.356.203/0001-80";

            _validator.ValidateEntity(_establishment);
        }
    }
}
