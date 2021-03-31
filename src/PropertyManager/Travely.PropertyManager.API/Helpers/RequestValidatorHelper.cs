using System;
using System.Linq;
using FluentValidation;
using Travely.Services.Common.CustomExceptions;

namespace Travely.PropertyManager.API.Helpers
{
    public static class RequestValidatorHelper
    {
        public static void EnsureValidity<TValidator, TModel>(this TModel model)
             where TValidator : IValidator<TModel>, new()
        {
            var validator = Activator.CreateInstance<TValidator>();

            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.FirstOrDefault()?.ErrorMessage;

                throw new BadRequestException(errorMessage);
            }
        }
    }
}
