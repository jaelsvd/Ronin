using System;
using System.Runtime.Serialization;

namespace App.BLL
{
    [Serializable]
    internal class IdentificadorAlreadyExistException : Exception
    {
        public IdentificadorAlreadyExistException()
        {
        }

        public IdentificadorAlreadyExistException(string message) : base(message)
        {
        }

        public IdentificadorAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdentificadorAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}