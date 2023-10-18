using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Validations.User;

namespace Domain.Commands.User
{
    public class DeleteUserCommand : UserCommand
    {
        public DeleteUserCommand(
            Guid id
        )
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}