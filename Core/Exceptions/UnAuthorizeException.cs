using System;

namespace Core.Exceptions
{
    public class UnAuthorizeException : Exception
    {
        public UnAuthorizeException() : base(ExceptionMessages.AuthorizationDenied)
        {
        }

        public UnAuthorizeException(string message) : base(message)
        {
        }

        public UnAuthorizeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
