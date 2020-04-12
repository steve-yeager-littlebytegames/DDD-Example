using DddExample.Domain.Validation;
using FluentValidation;

namespace DddExample.Domain.Models
{
    public class SectionValidator : AbstractValidator<Section>
    {
        public SectionValidator()
        {
            RuleFor(s => s.Name).Length(1, 50);
        }
    }

    public class Section
    {
        public string Name { get; }

        private Section(string name)
        {
            Name = name;
        }

        public static Result<Section> Construct(string name, SectionValidator validator)
        {
            var section = new Section(name);

            var result = validator.Validate(section);
            return Result<Section>.Construct(section, result);
        }
    }
}