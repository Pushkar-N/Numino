using System;
using System.Runtime.Serialization;

namespace CamelTraceTrack
{
    [Serializable]
    internal class NoPayoutException : Exception
    {
        public NoPayoutException()
        {
        }

        public NoPayoutException(string message) : base(message)
        {
            Console.WriteLine(string.Format("No Payout: {0}", message ));
        }

        public NoPayoutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPayoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}