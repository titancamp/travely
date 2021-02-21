using System;
using System.Net;
using System.Runtime.Serialization;

namespace FileService.Helpers
{
    public class RESTException : Exception
    {
        public string Code { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public RESTException() : base()
        {
            this.Code = string.Empty;
            this.StatusCode = HttpStatusCode.Forbidden;
        }
        public RESTException(string message) : base(message)
        {
            this.Code = string.Empty;
            this.StatusCode = HttpStatusCode.Forbidden;
        }
        public RESTException(string message, string code) : base(message)
        {
            this.Code = code;
            this.StatusCode = HttpStatusCode.InternalServerError;
        }
        public RESTException(string message, HttpStatusCode statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
        public RESTException(string message, HttpStatusCode statusCode, string code) : base(message)
        {
            this.Code = code;
            this.StatusCode = statusCode;
        }

        public RESTException(string message, Exception inner) : base(message, inner)
        {
            this.Code = string.Empty;
        }
        public RESTException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.Code = info.GetString("Code");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            info.AddValue("Code", this.Code);
            base.GetObjectData(info, context);
        }
    }
}