
using FluentValidation.Results;
using MediatR;

namespace Domain.Commands
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; protected set; }

        protected Command()
        {
            ValidationResult = new ValidationResult();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}