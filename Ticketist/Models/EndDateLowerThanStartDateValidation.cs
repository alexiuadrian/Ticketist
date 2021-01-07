using System;
using System.ComponentModel.DataAnnotations;

namespace Ticketist.Models
{
    public class EndDateLowerThanStartDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var project = (Project)validationContext.ObjectInstance;

            if (project.EndDate == null)
            {
                return ValidationResult.Success;
            }
            
            return (project.StartDate <= project.EndDate)
                ? ValidationResult.Success
                : new ValidationResult("The Start Date must be earlier than the End Date.");
        }
    }
}