using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Validators
{
    public interface IDocumentValidator
    {
        bool Validate(string document);
    }
}
