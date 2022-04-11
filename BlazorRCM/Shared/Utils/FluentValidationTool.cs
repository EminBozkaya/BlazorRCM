using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.Utils
{
    public static class FluentValidationTool<T>
    {
        public static void Validate(IValidator<T> validator, T obj)
        {
            ValidationResult result = validator.Validate(obj);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }

    }
}
