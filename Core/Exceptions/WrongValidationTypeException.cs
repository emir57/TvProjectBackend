using Core.Utilities.Messages;
using System;

namespace Core.Exceptions
{
    public class WrongValidationTypeException : Exception
    {
        public WrongValidationTypeException() : base(AspectMessages.WrongValidationType)
        {
        }

        public WrongValidationTypeException(string message) : base(message)
        {
        }

        public WrongValidationTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public static void ThrowIfNotEqualType(Type arg1, Type arg2)
        {
            if (arg1.IsAssignableFrom(arg2))
                throw new WrongValidationTypeException();
        }
    }
}
