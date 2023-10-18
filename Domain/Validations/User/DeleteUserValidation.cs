using Domain.Commands.User;

namespace Domain.Validations.User
{
    public class DeleteUserValidation : UserCommandValidations<DeleteUserCommand>
    {
        public DeleteUserValidation()
        {
            ValidateId();
        }
    }
}