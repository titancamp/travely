using System;

namespace Travely.Common.CustomExceptions
{
    public class BadRequestException : BusinessLayerException
    {
        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}