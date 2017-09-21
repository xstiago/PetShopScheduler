using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Exceptions
{
    public class EstablishmentValidatorException : Exception
    {
        public EstablishmentValidatorException() : base() { }
        public EstablishmentValidatorException(string message) : base(message) { }
        public EstablishmentValidatorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
