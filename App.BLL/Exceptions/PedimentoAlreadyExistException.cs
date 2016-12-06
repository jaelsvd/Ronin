using System;
using System.Runtime.Serialization;

namespace App.BLL
{
    [Serializable]
    public class PedimentoAlreadyExistException : Exception
    {
        public PedimentoAlreadyExistException()
        {
        }

        public PedimentoAlreadyExistException(string message) : base(message)
        {
        }

        public PedimentoAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PedimentoAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}