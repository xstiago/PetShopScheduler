using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Validators
{
    public class OwnerPetValidatorException : Exception
    {
        public OwnerPetValidatorException() : base() { }
        public OwnerPetValidatorException(string message) : base(message) { }
        public OwnerPetValidatorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
