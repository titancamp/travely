﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Net;
using Travely.Common.Api.Models;

namespace TourManager.Api.Utils
{
    public static class ModelStateDictionaryExtensions
    {
        public static ErrorResponse GetFirstErrorResponse(this ModelStateDictionary modelStateDictionary)
        {
            var modelState = modelStateDictionary.First();
            var errorMessage = modelState.Value.Errors.FirstOrDefault()?.ErrorMessage;

            return new ErrorResponse
            {
                Code = (int)HttpStatusCode.BadRequest,
                Message = errorMessage,
            };
        }
    }
}
