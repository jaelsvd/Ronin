using System;
using System.Runtime.Serialization;

namespace App.BLL
{
    [Serializable]
    internal class DataStageAlreadyExistException : Exception
    {
        public DataStageAlreadyExistException()
        {
        }

        public DataStageAlreadyExistException(string message) : base(message)
        {
        }

        public DataStageAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataStageAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}