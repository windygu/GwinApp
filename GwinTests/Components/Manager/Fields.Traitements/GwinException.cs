using System;
using System.Runtime.Serialization;

namespace GApp.GwinApp.FieldsTraitements.Tests
{
    [Serializable]
    internal class GwinException : Exception
    {
        public GwinException()
        {
        }

        public GwinException(string message) : base(message)
        {
        }

        public GwinException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GwinException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}