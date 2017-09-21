using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopScheduler.Entities
{
    public class ContractedService : BaseEntity
    {
        public Establishment Establishment { get; set; }
        public ServiceType ServiceType { get; set; }
        public long Value { get; set; }
    }
}