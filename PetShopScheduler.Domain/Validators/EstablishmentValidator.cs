using PetShopScheduler.Domain.Exceptions;
using PetShopScheduler.Domain.Interfaces;
using PetShopScheduler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopScheduler.Domain.Validators
{
    public class EstablishmentValidator : IValidatorBase<Establishment>
    {
        private IDocumentValidator _documentValidator;

        public EstablishmentValidator(IDocumentValidator documentValidator)
        {
            _documentValidator = documentValidator;
        }

        public void ValidateEntity(Establishment entity)
        {
            if (entity != null)
            {
                ValidateName(entity);
                ValidateDescription(entity);
                ValidateDocument(entity.Document);
            }
        }

        private void ValidateDocument(string document)
        {
            if (string.IsNullOrWhiteSpace(document))
                throw new EstablishmentValidatorException(Properties.Resources.EstablishmentDocumentError);

            if (!_documentValidator.Validate(document))
                throw new EstablishmentValidatorException(Properties.Resources.EstablishmentDocumentInvalidErro);
        }

        private void ValidateDescription(Establishment entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Description))
                throw new EstablishmentValidatorException(Properties.Resources.EstablishmentDescriptionError);
        }

        private void ValidateName(Establishment entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new EstablishmentValidatorException(Properties.Resources.EstablishmentNameError);
        }
    }
}
