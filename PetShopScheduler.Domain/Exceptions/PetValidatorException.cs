using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Exceptions
{
    public class PetValidatorException : Exception
    {
        public PetValidatorException() : base() { }
        public PetValidatorException(string message) : base(message) { }
        public PetValidatorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
