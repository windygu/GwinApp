using System;
using System.Runtime.Serialization;

namespace GApp.GwinApp.DataModel.Exceptions
{
    [Serializable]
    public class AnnotationNotExistException : Exception
    {
        public AnnotationNotExistException()
        {
        }

        public AnnotationNotExistException(string message) : base(message)
        {
        }

        public AnnotationNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AnnotationNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}