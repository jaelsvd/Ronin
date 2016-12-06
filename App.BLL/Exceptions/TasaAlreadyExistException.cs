using System;
using System.Runtime.Serialization;

namespace App.BLL
{
    [Serializable]
    internal class TasaAlreadyExistException : Exception
    {
        public TasaAlreadyExistException()
        {
        }

        public TasaAlreadyExistException(string message) : base(message)
        {
        }

        public TasaAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TasaAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}