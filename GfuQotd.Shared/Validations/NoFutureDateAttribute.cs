using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GfuQotd.Shared.Model;

namespace GfuQotd.Shared.Validations
{
    public class NoFutureDateAttribute : ValidationAttribute
    {
        public NoFutureDateAttribute()
        {
            //Falls User ErrorMessage NICHT gesetzt hat
            if (string.IsNullOrEmpty(ErrorMessage)) ErrorMessage = "Datum liegt in der Zukunft";
        }

        //public override bool IsValid(object? value)
        //{
            
        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //var authorCreateVm = (AuthorForCreateViewModel) validationContext.ObjectInstance;

            if (value is DateOnly dateToCheck)
            {
                if (dateToCheck > DateOnly.FromDateTime(DateTime.Today))
                {
                    return new ValidationResult(ErrorMessage, memberNames: [validationContext.MemberName ?? validationContext.DisplayName]);
                }
            }

            return ValidationResult.Success;
        }
    }
}
