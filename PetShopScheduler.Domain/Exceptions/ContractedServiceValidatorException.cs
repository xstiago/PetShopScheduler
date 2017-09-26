using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Exceptions
{
    public class ContractedServiceValidatorException : Exception
    {
        public ContractedServiceValidatorException() : base() { }
        public ContractedServiceValidatorException(string message) : base(message) { }
        public ContractedServiceValidatorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
