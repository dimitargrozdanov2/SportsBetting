using SportsBetting.Data.Utils;
using System;

namespace SportsBetting.Data.Exceptions
{
    public class EntityExistsException : Exception
    {

        public EntityExistsException() : base(ErrorConstants.EntityExists)
        {
        }

        public EntityExistsException(string message) : base(message)
        {
        }

        public EntityExistsException(string message, Exception innerException) : base(message,
             innerException)
        {
        }
    }
}
