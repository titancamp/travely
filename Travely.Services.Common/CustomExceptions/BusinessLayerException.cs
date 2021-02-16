using System;

namespace Travely.Services.Common.CustomExceptions
{
    public class BusinessLayerException : Exception
    {
        public BusinessLayerException(string message)
            : base(message)
        {
        }
    }
}