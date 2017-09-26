using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Exceptions
{
    public class ScheduleValidatorException : Exception
    {
        public ScheduleValidatorException() : base() { }
        public ScheduleValidatorException(string message) : base(message) { }
        public ScheduleValidatorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
