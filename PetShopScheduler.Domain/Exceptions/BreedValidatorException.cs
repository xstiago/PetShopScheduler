using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Exceptions
{
    public class BreedValidatorException : Exception
    {
        public BreedValidatorException() : base() { }
        public BreedValidatorException(string message) : base(message) { }
        public BreedValidatorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
