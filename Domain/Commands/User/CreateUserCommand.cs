using Domain.Validations.User;

namespace Domain.Commands.User
{
    public class CreateUserCommand : UserCommand
    {
        public CreateUserCommand(
            string name,
            string cpf,
            string email
        )
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
            this.Name = name;
            this.Cpf = cpf;
            this.Email = email;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}