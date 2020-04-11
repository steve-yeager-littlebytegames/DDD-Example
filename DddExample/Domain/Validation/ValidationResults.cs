using System.Collections.Generic;
using System.Linq;

namespace DddExample.Domain.Validation
{
    public class ValidationResults
    {
        private readonly Dictionary<string, List<ValidationError>> errors = new Dictionary<string, List<ValidationError>>();

        private bool IsSuccess => errors.Count == 0;

        public static void AddError(ref ValidationResults? results, string key, ValidationError error)
        {
            results ??= new ValidationResults();
            results.AddError(key, error);
        }

        private void AddError(string key, ValidationError error)
        {
            // TODO: validation

            if(!errors.TryGetValue(key, out var messages))
            {
                errors[key] = messages = new List<ValidationError>();
            }

            messages.Add(error);
        }

        public void ThrowIfFailed()
        {
            if(!IsSuccess)
            {
                var readonlyErrors = errors.ToDictionary(pair => pair.Key, pair => (IReadOnlyList<ValidationError>)pair.Value);
                throw new ValidationException(readonlyErrors);
            }
        }
    }
}