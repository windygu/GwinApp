using System;
using System.Runtime.Serialization;

namespace GenericWinFormApplication
{
    [Serializable]
    internal class GwinAccessException : Exception
    {
        public GwinAccessException()
        {
        }

        public GwinAccessException(string message) : base(message)
        {
        }

        public GwinAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GwinAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}