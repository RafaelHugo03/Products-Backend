using Domain.Repositories;
using FluentValidation.Results;

namespace Domain.Handlers
{
    public abstract class CommandHandler
    {
        public ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        private ValidationResult Commit(IUnitOfWork uow, string message)
        {
            if (!uow.Commit()) AddError(message);

            return ValidationResult;
        }

        protected ValidationResult Commit(IUnitOfWork uow)
        {
            return Commit(uow, "There was an error saving data");
        }
    }
}