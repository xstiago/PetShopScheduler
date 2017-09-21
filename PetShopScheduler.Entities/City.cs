using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public State State { get; set; }
    }
}
