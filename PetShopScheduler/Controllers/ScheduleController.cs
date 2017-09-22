using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetShopScheduler.Controllers
{
    public class ScheduleController : ApiController
    {
        private IDomainBase<Schedule> _scheduleDomain;
        
        public ScheduleController(IDomainBase<Schedule> scheduleDomain)
        {
            _scheduleDomain = scheduleDomain;
        }
        
        [HttpGet]
        public Schedule Get(long id)
        {
            return _scheduleDomain.Get(id);
        }

        [HttpPost]
        public void Add(Schedule schedule)
        {
            _scheduleDomain.Add(schedule);
        }
    }
}
