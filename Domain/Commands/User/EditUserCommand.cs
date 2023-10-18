using Domain.Validations.User;

namespace Domain.Commands.User
{
    public class EditUserCommand : UserCommand
    {
        public EditUserCommand(
            Guid id,
            string name,
            string email,
            string cpf
        )
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Cpf = cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}