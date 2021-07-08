using System;
using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate != null)
            {
                var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

                return (age >= 18)
                    ? ValidationResult.Success
                    : new ValidationResult("Customer should be at least 18 years old to use this plan.");
            }
            else
            {
                return new ValidationResult("Birthday is required for this plan.");
            }
        }
    }
} 