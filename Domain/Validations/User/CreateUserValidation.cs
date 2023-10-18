using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commands.User;
using FluentValidation;

namespace Domain.Validations.User
{
    public class CreateUserValidation : UserCommandValidations<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidateCpf();
        }
    }
}