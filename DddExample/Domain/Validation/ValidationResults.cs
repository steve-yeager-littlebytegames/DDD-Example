using System.Collections.Generic;
using System.Linq;

namespace DddExample.Domain.Validation
{
    public class ValidationResults
    {
        private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public IReadOnlyDictionary<string, IReadOnlyList<string>> Errors => errors.ToDictionary(pair => pair.Key, pair => (IReadOnlyList<string>)pair.Value);
        public bool HasError => errors.Count > 0;

        public void AddError(string key, string message)
        {
            // TODO: validation

            if(!errors.TryGetValue(key, out var messages))
            {
                errors[key] = messages = new List<string>();
            }

            messages.Add(message);
        }

        public void ThrowIfFailed()
        {
            if(HasError)
            {
                throw new ValidationException(Errors);
            }
        }

        public static void AddError(ref ValidationResults? results, string key, string message)
        {
            results ??= new ValidationResults();
            results.AddError(key, message);
        }
    }
}