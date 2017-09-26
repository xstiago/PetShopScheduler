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
    public class OwnerPetValidatorTest
    {
        private IValidatorBase<OwnerPet> _validator;
        private OwnerPet _ownerPet;

        [TestInitialize]
        public void Initialize()
        {
            _validator = new OwnerPetValidator(new CpfValidator());
            _ownerPet = new OwnerPet();
        }

        [TestMethod]
        [ExpectedException(typeof(OwnerPetValidatorException))]
        public void EstablishmentToValidateIsNullTest()
        {
            _validator.ValidateEntity(null);
        }

        [TestMethod]
        [ExpectedException(typeof(OwnerPetValidatorException))]
        public void CpfAtEstablishmentIsInvalidTest()
        {
            _ownerPet.Name = "OwnerPetName";
            _ownerPet.Address = "OwnerPetAddress";
            _ownerPet.AddressNumber = "OwnerPetAddressNumber";
            _ownerPet.District = "OwnerPetDistrict";
            _ownerPet.ZipCode = "OwnerPetZipCode";
            _ownerPet.City = new City();
            _ownerPet.State = new State();

            _ownerPet.Document = "81592731698";

            _validator.ValidateEntity(_ownerPet);
        }

        [TestMethod]
        public void CpfAtEstablishmentIsValidTest()
        {
            _ownerPet.Name = "OwnerPetName";
            _ownerPet.Address = "OwnerPetAddress";
            _ownerPet.AddressNumber = "OwnerPetAddressNumber";
            _ownerPet.District = "OwnerPetDistrict";
            _ownerPet.ZipCode = "OwnerPetZipCode";
            _ownerPet.PhoneNumber1 = "99999999";
            _ownerPet.City = new City();
            _ownerPet.State = new State();

            _ownerPet.Document = "59478273108";

            _validator.ValidateEntity(_ownerPet);
        }

        [TestMethod]
        public void CpfAtEstablishmentIsValidWithSpecialCharsTest()
        {
            _ownerPet.Name = "OwnerPetName";
            _ownerPet.Address = "OwnerPetAddress";
            _ownerPet.AddressNumber = "OwnerPetAddressNumber";
            _ownerPet.District = "OwnerPetDistrict";
            _ownerPet.ZipCode = "OwnerPetZipCode";
            _ownerPet.PhoneNumber1 = "99999999";
            _ownerPet.City = new City();
            _ownerPet.State = new State();

            _ownerPet.Document = "641.358.709-10";

            _validator.ValidateEntity(_ownerPet);
        }
    }
}
