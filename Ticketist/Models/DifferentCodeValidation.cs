using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ticketist.Models
{
    public class DifferentCodeValidation : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public DifferentCodeValidation()
        {
            _context = new ApplicationDbContext();
        }
        protected void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var organization = (Organization)validationContext.ObjectInstance;

            var org = _context.Organizations.SingleOrDefault(o => o.Code == organization.Code);


            if (org != null)
            {
                if (org.Id == organization.Id)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("There is already an organization with this code.");
                }
            }
            else
            {
                return ValidationResult.Success;
            }
            
        }
    }
}