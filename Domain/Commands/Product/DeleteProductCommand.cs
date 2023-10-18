using Domain.Validations.Product;

namespace Domain.Commands.Product
{
    public class DeleteProductCommand : ProductCommand
    {
        public DeleteProductCommand(
            Guid id
        )
        {
            this.Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}