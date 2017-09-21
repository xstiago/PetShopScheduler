using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Entities
{
    public class AppointmentBook : BaseEntity
    {
        public IEnumerable<DateTime> FreeDays { get; set; }
        public IEnumerable<DateTime> BusyDays { get; set; }
        public IEnumerable<DayOfWeek> WorkDays { get; set; }
        public TimeSpan FirstTimeOfWorkDay { get; set; }
        public TimeSpan LastTimeOfWorkDay { get; set; }
    }
}
