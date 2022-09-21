using Core.Utilities.Messages;
using System;

namespace Core.Exceptions
{
    public class WrongLoggingTypeException : Exception
    {
        public WrongLoggingTypeException() : base(AspectMessages.WrongLoggingType)
        {
        }

        public WrongLoggingTypeException(string message) : base(message)
        {
        }

        public WrongLoggingTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public static void ThrowIfNotEqual(object arg1, Type arg2)
        {
            if (arg1.GetType().IsAssignableFrom(arg2) == false)
                throw new WrongLoggingTypeException();
        }
    }
}
