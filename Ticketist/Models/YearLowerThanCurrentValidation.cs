using System;
using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class YearLowerThanCurrentValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var organization = (Organization)validationContext.ObjectInstance;

            return (organization.FoundationYear <= DateTime.Now.Year)
                ? ValidationResult.Success
                : new ValidationResult("The organization cannot be founded in the future.");
        }
    }
}