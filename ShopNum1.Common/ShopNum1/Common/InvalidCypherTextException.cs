using System;

namespace ShopNum1.Common
{
    public class InvalidCypherTextException : Exception
    {
        public InvalidCypherTextException()
        {
        }

        public InvalidCypherTextException(string message) : base(message)
        {
        }

        public InvalidCypherTextException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}