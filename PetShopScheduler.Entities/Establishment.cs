using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopScheduler.Entities
{
    public class Establishment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Document { get; set; }
        public AppointmentBook AppointmentBook { get; set; }
    }
}