using System;

namespace Travely.Common.CustomExceptions
{
    public abstract class BusinessLayerException : Exception
    {
        public BusinessLayerException(string message)
            : base(message)
        {
        }
    }
}