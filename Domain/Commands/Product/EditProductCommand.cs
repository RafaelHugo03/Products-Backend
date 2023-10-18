using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Validations.Product;

namespace Domain.Commands.Product
{
    public class EditProductCommand : ProductCommand
    {
        public EditProductCommand(
            Guid id,
            string name,
            decimal price,
            Guid userId
        )
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}