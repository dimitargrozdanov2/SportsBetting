using SportsBetting.Data.Exceptions;
using SportsBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBetting.Data.Utils
{
    public static class ObjectCheck
    {
        public static void EntityCheck(IEntity entity, string message = null)
        {
            if (entity == null)
            {
                if (message == null)
                    message = ErrorConstants.NotFound;

                throw new NotFoundException(message);
            }
        }

        public static void PrimaryKeyCheck(object primaryKey, string message = null)
        {
            if (primaryKey == null || primaryKey.ToString() == "0")
            {
                if (message == null)
                    message = ErrorConstants.PrimaryKeyNullError;
                throw new NotFoundException(message);
            }
        }
    }
}
