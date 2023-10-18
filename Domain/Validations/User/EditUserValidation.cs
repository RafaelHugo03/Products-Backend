using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commands.User;

namespace Domain.Validations.User
{
    public class EditUserValidation : UserCommandValidations<EditUserCommand>
    {
        public EditUserValidation()
        {
            ValidateId();
            ValidateName();
            ValidateEmail();
            ValidateCpf();
        }
    }
}