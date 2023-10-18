using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Commands.User;
using FluentValidation;

namespace Domain.Validations.User
{
    public abstract class UserCommandValidations<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateId()
        {
            RuleFor(u => u.Id).NotEmpty().NotNull().NotEqual(Guid.Empty).WithMessage("Informe o Id do usuário");
        }

        protected void ValidateName()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("Informe o nome do usuário");
        }

        protected void ValidateEmail()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("E-mail inválido");
        }

        protected void ValidateCpf()
        {
            RuleFor(u => u.Cpf).Must(ValidateCpf).WithMessage("Cpf inválido");
        }

        private bool ValidateCpf(string cpf)
        {
            string pattern = "[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}";
            return Regex.IsMatch(cpf, pattern);
        }
    }
}