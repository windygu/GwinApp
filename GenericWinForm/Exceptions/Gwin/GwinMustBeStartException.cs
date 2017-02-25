using System;
using System.Runtime.Serialization;

namespace App.WinForm.Exceptions.Gwin
{
    [Serializable]
    internal class GwinMustBeStartException : Exception
    {
        public GwinMustBeStartException()
        {
        }

        public GwinMustBeStartException(string message) : base(message)
        {
        }

        public GwinMustBeStartException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GwinMustBeStartException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}