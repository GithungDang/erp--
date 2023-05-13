namespace ZedGraph
{
    using System;
    using System.Runtime.Serialization;

    public class ZedGraphException : ApplicationException
    {
        public ZedGraphException()
        {
        }

        public ZedGraphException(string message) : base(message)
        {
        }

        protected ZedGraphException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ZedGraphException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

