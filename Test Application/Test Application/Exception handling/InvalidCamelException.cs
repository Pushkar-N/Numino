using System;
using System.Runtime.Serialization;

namespace CamelTraceTrack
{
    [Serializable]
    internal class InvalidCamelException : Exception
    {
        public InvalidCamelException()
        {
        }

        public InvalidCamelException(string message) : base(message)
        {
            Console.WriteLine(string.Format("Invalid Camel Number: {0}", message));
        }

        public InvalidCamelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCamelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}