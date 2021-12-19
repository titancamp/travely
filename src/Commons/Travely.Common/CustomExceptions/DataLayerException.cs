using System;

namespace Travely.Common.CustomExceptions
{
    public abstract class DataLayerException : Exception
    {
        public DataLayerException(string message)
        : base(message)
        { }
    }
}