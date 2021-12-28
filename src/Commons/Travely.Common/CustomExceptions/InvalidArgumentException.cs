using System;

namespace Travely.Common.CustomExceptions
{
    public class InvalidArgumentException : BusinessLayerException
    {
        public InvalidArgumentException(string message)
            : base(message)
        {
        }
    }
}