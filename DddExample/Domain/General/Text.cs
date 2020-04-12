using DddExample.Domain.Validation;
using DddExample.Domain.Validation.Errors;

namespace DddExample.Domain.General
{
    public class Text
    {
        public string Value { get; }

        private Text(string value)
        {
            Value = value;
        }

        public static implicit operator string(Text text) => text.Value;

        public override string ToString() => Value;

        public static Text Build(string value, string name, Range range, ref ValidationResults? validation)
        {
            value = value.Trim();

            if(!range.IsValid(value.Length))
            {
                ValidationResults.AddError(
                    ref validation,
                    name,
                    new LengthValidationError(range.Min, range.Max));
            }

            return new Text(value);
        }
    }
}