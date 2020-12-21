using SportsBetting.Data.Utils;
using System;

namespace SportsBetting.Data.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base(ErrorConstants.BadRequest)
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message,
             innerException)
        {
        }
    }
}
