using System;
using System.Runtime.Serialization;

namespace BaseApp.Common
{
    [Serializable]
    public class ValidationException : Exception, ISerializable
    {
        private string paramName;

        public ValidationException() : base()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, string paramName) : base(message)
        {
            this.paramName = paramName;
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public virtual string ParamName
        {
            get { return paramName; }
        }
    }
}
