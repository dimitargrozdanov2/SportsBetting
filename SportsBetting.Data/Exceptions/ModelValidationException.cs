using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsBetting.Data.Exceptions
{
    public class ModelValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ModelValidationException()
           : base("One or more validation errors have occurred.")
           => this.Errors = new Dictionary<string, string[]>();

        public ModelValidationException(IEnumerable<ValidationFailure> errors)
            : this()
        {
            var failureGroups = errors
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                this.Errors.Add(propertyName, propertyFailures);
            }
        }

    }
}
