using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Entities;
using FluentValidation;

namespace Infrastructure.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(AbstractValidator<object> validator,object entity)
        {
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
