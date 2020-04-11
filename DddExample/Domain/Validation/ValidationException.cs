using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DddExample.Domain.Validation
{
    public class ValidationException : Exception
    {
        public IReadOnlyDictionary<string, IReadOnlyList<ValidationError>> Errors { get; }

        public ValidationException(IReadOnlyDictionary<string, IReadOnlyList<ValidationError>> errors)
            :base(ErrorsToStrings(errors))
        {
            Errors = errors;
        }

        private static string ErrorsToStrings(IReadOnlyDictionary<string, IReadOnlyList<ValidationError>> errors)
        {
            var builder = new StringBuilder();

            var totalCount = errors.Sum(e => e.Value.Count).ToString();
            builder.AppendLine($"Total Errors: {totalCount}");

            foreach(var (key, value) in errors)
            {
                var errorCount = key.Length.ToString();
                builder.AppendLine($"Errors for '{key}': {errorCount}");
                
                foreach(var error in value)
                {
                    builder.AppendLine(error.Message);
                }
            }

            return builder.ToString();
        }
    }
}