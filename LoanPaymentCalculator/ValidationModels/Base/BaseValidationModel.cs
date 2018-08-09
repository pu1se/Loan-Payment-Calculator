using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LoanPaymentCalculator
{
    abstract class BaseValidationModel<T>
    {
        private string _validationError = null;

        public string GetValidationError()
        {
            if (_validationError.IsNullOrEmpty())
                IsValid();

            return _validationError;
        }

        public bool IsValid()
        {
            var validationResultList = new List<ValidationResult>();
            var validationContext = new ValidationContext(this, null, null);
            var isValid = Validator.TryValidateObject(this, validationContext, validationResultList, true);

            _validationError = validationResultList.Select(x=>x.ErrorMessage).Join(Environment.NewLine);

            return isValid;
        }

        public abstract T ToEntity();
    }
}
