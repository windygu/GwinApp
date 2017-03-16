using System;
using System.Runtime.Serialization;

namespace App.Gwin.Exceptions.Gwin
{
    [Serializable]
    internal class GwinNotImplementedException : Exception
    {
        public GwinNotImplementedException()
        {
        }

        public GwinNotImplementedException(string message) : base(message)
        {
        }

        public GwinNotImplementedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GwinNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}