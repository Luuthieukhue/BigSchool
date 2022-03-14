using System;
using System.Runtime.Serialization;

namespace Lab2_luuthieukhue .Controllers 
{
    [Serializable]
    internal class RetryLimitExceedExeption : Exception
    {
        public RetryLimitExceedExeption()
        {
        }

        public RetryLimitExceedExeption(string message) : base(message)
        {
        }

        public RetryLimitExceedExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RetryLimitExceedExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}