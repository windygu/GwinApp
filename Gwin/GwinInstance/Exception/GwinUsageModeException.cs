using System;
using System.Runtime.Serialization;

namespace GApp.GwinApp.Exceptions.Gwin
{
    [Serializable]
    public class GwinUsageModeException : Exception
    {
        public GwinUsageModeException()
        {
        }

        public GwinUsageModeException(string message) : base(message)
        {
        }

        public GwinUsageModeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GwinUsageModeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}