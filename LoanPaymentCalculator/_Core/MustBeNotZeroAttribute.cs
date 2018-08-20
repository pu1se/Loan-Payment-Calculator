using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanPaymentCalculator
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MustBeNotZeroAttribute : ValidationAttribute
    {
        private string GetErrorMessage(ValidationContext validationContext)
        {
            if (!ErrorMessage.IsNullOrEmpty())
            {
                return ErrorMessage;
            }

            return $"{validationContext.DisplayName} must be greater than zero";
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            decimal currentPropertyNumber;

            if (!decimal.TryParse(value.ToString().Replace("%", ""), out currentPropertyNumber))
            {
                return ValidationResult.Success;
            }

            if (currentPropertyNumber > 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }
        }
    }
}
