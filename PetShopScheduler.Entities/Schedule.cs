using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopScheduler.Entities
{
    public class Schedule : BaseEntity
    {
        public Establishment Establishment { get; set; }
        public Pet Pet { get; set; }
        public DateTime DateToDo { get; set; }
        public ContractedService ContractedService { get; set; }
        public long ServiceValue { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Approved { get; set; }
    }
}