using System;

namespace Travely.Services.Common.CustomExceptions
{
    public class InvalidArgumentException : BusinessLayerException
    {
        public InvalidArgumentException(string message)
            : base(message)
        {
        }
    }
}