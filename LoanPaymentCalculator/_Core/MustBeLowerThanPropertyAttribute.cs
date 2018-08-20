using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanPaymentCalculator
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MustBeLowerThanPropertyAttribute : ValidationAttribute
    {
        private readonly string anotherPropertyName;
        public MustBeLowerThanPropertyAttribute(string anotherPropertyName)
        {
            this.anotherPropertyName = anotherPropertyName;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            if (!ErrorMessage.IsNullOrEmpty())
            {
                return ErrorMessage;
            }

            var anotherProperty = validationContext.ObjectType.GetProperty(anotherPropertyName);
            return $"{validationContext.DisplayName} must be lower than {anotherProperty.GetDisplayName()}";
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            decimal currentPropertyNumber;

            if (!decimal.TryParse(value.ToString(), out currentPropertyNumber))
            {
                return ValidationResult.Success;
            }

            object anotherPropertyValue = validationContext.ObjectType.GetProperty(anotherPropertyName).GetValue(validationContext.ObjectInstance, null);

            if (anotherPropertyValue == null)
            {
                return ValidationResult.Success;
            }

            decimal anotherPropertyNumber;
            if (!decimal.TryParse(anotherPropertyValue.ToString(), out anotherPropertyNumber))
            {
                return ValidationResult.Success;
            }

            if (anotherPropertyNumber > currentPropertyNumber)
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
