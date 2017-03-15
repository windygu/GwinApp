using System;
using System.Runtime.Serialization;

namespace App.Gwin.Exceptions.Gwin
{
    [Serializable]
    public  class GwinNullParameterException : Exception
    {
        public GwinNullParameterException()
        {
        }

        public GwinNullParameterException(string message) : base(message)
        {
        }

        public GwinNullParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GwinNullParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}