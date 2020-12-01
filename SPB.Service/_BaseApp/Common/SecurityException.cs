
using System;
using System.Runtime.Serialization;

namespace BaseApp.Common
{
    [Serializable]
    public class SecurityException : Exception, ISerializable
    {
        private string paramName;

        public SecurityException() : base()
        {
        }

        public SecurityException(string message) : base(message)
        {
        }

        public SecurityException(string message, string paramName) : base(message)
        {
            this.paramName = paramName;
        }

        public SecurityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SecurityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public virtual string ParamName
        {
            get { return paramName; }
        }
    }
}