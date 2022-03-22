using System;
using System.Runtime.Serialization;

namespace CamelTraceTrack
{
    [Serializable]
    internal class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {
        }

        public InvalidCommandException(string message) : base(message)
        {
            Console.WriteLine(string.Format("Invalid Command: {0}", message));
        }

        public InvalidCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}