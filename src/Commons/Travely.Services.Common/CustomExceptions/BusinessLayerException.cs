using System;

namespace Travely.Services.Common.CustomExceptions
{
    public abstract class BusinessLayerException : Exception
    {
        public BusinessLayerException(string message)
            : base(message)
        {
        }
    }
}