using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopScheduler.Entities
{
    public class OwnerPet : BaseEntity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public string FoneNumber1 { get; set; }
        public string FoneNumber2 { get; set; }
    }
}