using System;
using System.Runtime.Serialization;

namespace CamelTraceTrack
{
    [Serializable]
    internal class InvalidBetException : Exception
    {
        public InvalidBetException()
        {
        }

        public InvalidBetException(string message) : base(message)
        {
            Console.WriteLine(string.Format("Invalid Bet: {0}", message));
        }

        public InvalidBetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}