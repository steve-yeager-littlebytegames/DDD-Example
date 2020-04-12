using DddExample.Domain.Validation;
using FluentValidation;

namespace DddExample.Domain.Models
{
    public class Chef
    {
        public class Validator : AbstractValidator<Chef>
        {
            public Validator()
            {
                RuleFor(c => c.Name).Length(1, 50);
            }
        }

        public readonly struct Guid
        {
            public System.Guid Value { get; }

            public Guid(System.Guid guid)
            {
                Value = guid;
            }
        }

        public Guid ID { get; }
        public string Name { get; }

        private Chef(Guid id, string name)
        {
            ID = id;
            Name = name;
        }

        public static Result<Chef> Construct(Guid? id, string name, Validator? validator)
        {
            id ??= new Guid(new System.Guid());
            validator ??= new Validator();
            
            var chef = new Chef(id.Value, name);

            var results = validator.Validate(chef);
            return Result<Chef>.Construct(chef, results);
        }
    }
}