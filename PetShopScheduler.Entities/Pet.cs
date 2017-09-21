using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopScheduler.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public Breed Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public long Weigth { get; set; }
        public OwnerPet OwnerPet { get; set; }
    }
}