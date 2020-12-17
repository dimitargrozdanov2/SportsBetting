using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBetting.Data.Utils
{
    public static class ErrorConstants
    {
        public static readonly string BadRequest = "BadRequest";

        public static readonly string NotFound = "Entity NotFound";

        public static readonly string NoInformationProvided = "No information provided";

        public static readonly string EntityExists = "EntityExists";

        public static readonly string ModelValidationErrors = "ModelValidationErrors";

        public static readonly string PrimaryKeyNullError = "Primary key cannot be null!";

    }
}
