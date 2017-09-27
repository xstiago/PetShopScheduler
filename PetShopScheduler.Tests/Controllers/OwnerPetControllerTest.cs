using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetShopScheduler.Controllers;
using PetShopScheduler.DataAccess;
using PetShopScheduler.Domain;
using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Domain.Validators;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShopScheduler.Tests.Controllers
{
    [TestClass]
    public class OwnerPetControllerTest
    {
        private IRepository<OwnerPet> _mockOwnerPetRepository;
        private OwnerPetController _ownerPetController;

        public OwnerPetControllerTest()
        {
            InitMocks();

            var ownerPetValidator = new OwnerPetValidator(new CpfValidator());
            var ownerPetDomain = new OwnerPetDomain(ownerPetValidator, _mockOwnerPetRepository);

            _ownerPetController = new OwnerPetController(ownerPetDomain);
        }

        private void InitMocks()
        {
            IList<OwnerPet> listOwnerPet = new List<OwnerPet>()
            {
                new OwnerPet(){
                    AddedDate = DateTime.Now,
                    Address = "Street One",
                    AddressNumber = "100",
                    City = new City()
                    {
                        AddedDate = DateTime.Now,
                        ID = 1,
                        Name = "Cansas"
                    },
                    District = "Gregory",
                    Document = "44956314540",
                    ID = 1,
                    Name = "John",
                    PhoneNumber1 = "999999999",
                    State = new State()
                    {
                        AddedDate = DateTime.Now,
                        ID = 1,
                        Name = "Chicago"
                    },
                    ZipCode = "55555555"
                },
                new OwnerPet(){
                    AddedDate = DateTime.Now,
                    Address = "Street Two",
                    AddressNumber = "200",
                    City = new City()
                    {
                        AddedDate = DateTime.Now,
                        ID = 2,
                        Name = "Ringo"
                    },
                    District = "George",
                    Document = "13474133594",
                    ID = 2,
                    Name = "Ivy",
                    PhoneNumber1 = "999999999",
                    State = new State()
                    {
                        AddedDate = DateTime.Now,
                        ID = 1,
                        Name = "New York"
                    },
                    ZipCode = "55555555"
                }
            };

            Mock<IRepository<OwnerPet>> mockOwnerPetRepository = new Mock<IRepository<OwnerPet>>();

            mockOwnerPetRepository
                .Setup(o => o.Get(It.IsAny<long>()))
                .Returns((long o) => listOwnerPet
                    .Where(x => x.ID == o && !x.IsDeleted)
                    .Single());

            //mockOwnerPetRepository
            //    .Setup(o => o.Get(It.IsAny<Expression<Func<OwnerPet, bool>>>()))
            //    .Returns((Expression<Func<OwnerPet, bool>> exp) => listOwnerPet
            //        .Where(exp));

            mockOwnerPetRepository
                .Setup(o => o.Insert(It.IsAny<OwnerPet>()))
                .Callback((OwnerPet target) =>
                {
                    DateTime now = DateTime.Now;

                    if (target.ID.Equals(default(long)))
                    {
                        target.AddedDate = now;
                        target.ID = listOwnerPet.Count() + 1;
                        listOwnerPet.Add(target);
                    }
                });

            mockOwnerPetRepository
                .Setup(o => o.Update(It.IsAny<OwnerPet>()))
                .Callback((OwnerPet target) =>
                {
                    DateTime now = DateTime.Now;

                    var original = listOwnerPet
                        .Where(q => q.ID == target.ID)
                        .Single();

                    if (original == null)
                        return;

                    original.Address = target.Address;
                    original.AddressNumber = target.AddressNumber;
                    original.City = target.City;
                    original.Complement = target.Complement;
                    original.District = target.District;
                    original.Document = target.Document;
                    original.Name = target.Name;
                    original.PhoneNumber1 = target.PhoneNumber1;
                    original.PhoneNumber2 = target.PhoneNumber2;
                    original.State = target.State;
                    original.ZipCode = target.ZipCode;
                    original.ModifiedDate = now;
                });

            mockOwnerPetRepository
                .Setup(o => o.Delete(It.IsAny<OwnerPet>()))
                .Callback((OwnerPet target) =>
                {
                    target.IsDeleted = true;
                    target.ModifiedDate = DateTime.Now;
                });

            _mockOwnerPetRepository = mockOwnerPetRepository.Object;
        }

        [TestMethod]
        public void CanGetOwnerPetById()
        {
            var ownerPet = _ownerPetController.Get(2);

            Assert.IsNotNull(ownerPet);
            Assert.IsInstanceOfType(ownerPet, typeof(OwnerPet));
            Assert.AreEqual(2, ownerPet.ID);
        }

        [TestMethod]
        public void CanInsertOwnerPetData()
        {
            var ownerPet = new OwnerPet()
            {
                AddedDate = DateTime.Now,
                Address = "Street Test",
                AddressNumber = "500",
                City = new City()
                {
                    AddedDate = DateTime.Now,
                    ID = 3,
                    Name = "Tupila"
                },
                District = "Gregory",
                Document = "42888677547",
                Name = "Julia",
                PhoneNumber1 = "999999999",
                State = new State()
                {
                    AddedDate = DateTime.Now,
                    ID = 3,
                    Name = "Hippie"
                },
                ZipCode = "55555555"
            };

            _ownerPetController.Add(ownerPet);
        }
    }
}
