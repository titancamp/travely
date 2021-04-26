using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.IdentityManager.Service.Identity
{

    [Serializable]
    public class IdentityException : Exception
    {

        public IdentityException() { }
        public IdentityException(string message) : base(message) { }
        public IdentityException(string message, Exception inner) : base(message, inner) { }
        protected IdentityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class UserNotFoundException : IdentityException
    {
        public UserNotFoundException() : this("User not found.") { }
        public UserNotFoundException(string message) : base(message) { }
        public UserNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected UserNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class AgencyNotFoundException : IdentityException
    {
        public AgencyNotFoundException() { }
        public AgencyNotFoundException(string message) : base(message) { }
        public AgencyNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected AgencyNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class NotPermitedException : IdentityException
    {
        public NotPermitedException() :this("Operation not permited.") { }
        public NotPermitedException(string message) : base(message) { }
        public NotPermitedException(string message, Exception inner) : base(message, inner) { }
        protected NotPermitedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
