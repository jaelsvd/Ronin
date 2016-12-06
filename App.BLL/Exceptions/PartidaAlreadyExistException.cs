using System;
using System.Runtime.Serialization;

namespace App.BLL
{
    [Serializable]
    public class PartidaAlreadyExistException : Exception
    {
        public PartidaAlreadyExistException()
        {
        }

        public PartidaAlreadyExistException(string message) : base(message)
        {
        }

        public PartidaAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PartidaAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}