using Domain.Validations.Product;

namespace Domain.Commands.Product
{
    public class CreateProductCommand : ProductCommand
    {
        public CreateProductCommand(
            string name,
            decimal price,
            Guid userId
        )
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.CreatedAt = DateTime.Now;
            this.Price = price;
            this.UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}