using SportsBetting.Data.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBetting.Data.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException() : base(ErrorConstants.NotFound)
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message,
             innerException)
        {
        }
    }
}
