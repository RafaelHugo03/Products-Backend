using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commands.Product;
using FluentValidation;

namespace Domain.Validations.Product
{
    public abstract class ProductCommandValidations<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateId()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().NotEqual(Guid.Empty).WithMessage("Informe o ID do produto");
        }

        protected void ValidateName()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Informe o nome do produto");
        }

        protected void ValidatePrice()
        {
            RuleFor(p => p.Price).GreaterThanOrEqualTo(0).WithMessage("Não pode inserir valor negativo");
        }

        protected void ValidateUserId()
        {
            RuleFor(p => p.UserId)
                .NotNull()
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .WithMessage("Inform o id do usuário responsável pelo produto");
        }
    }
}