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
        [HttpGet]
        public Schedule Get(long id)
        {
            return new Schedule();
        }

        [HttpPost]
        public void Add(Schedule schedule)
        {
        }
    }
}
