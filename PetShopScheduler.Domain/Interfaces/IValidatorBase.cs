using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopScheduler.Domain.Interfaces
{
    public interface IValidatorBase<T>
    {
        void ValidateEntity(T entity);
    }
}
