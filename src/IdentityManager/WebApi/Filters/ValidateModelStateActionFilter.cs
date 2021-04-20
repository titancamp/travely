using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using Travely.IdentityManager.Service.Abstractions.Models.Error;

namespace Travely.IdentityManager.WebApi.Filters
{
    public class ValidateModelStateActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {

            List<ValidationErrorModel> messages = new List<ValidationErrorModel>();

            if (!context.ModelState.IsValid)
            {
                foreach (string key in context.ModelState.Keys)
                {
                    foreach (ModelError error in context.ModelState[key].Errors)
                    {
                        messages.Add(new ValidationErrorModel
                        {
                            Message = error.ErrorMessage,
                            Name = key
                        });
                    }
                }

                if (messages.Any())
                {
                    context.Result = new JsonResult(messages)
                    {
                        StatusCode = 400
                    };
                }
            }

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
