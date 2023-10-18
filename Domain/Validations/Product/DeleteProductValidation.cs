using Domain.Commands.Product;

namespace Domain.Validations.Product
{
    public class DeleteProductValidation : ProductCommandValidations<DeleteProductCommand>
    {
        public DeleteProductValidation()
        {
            ValidateId();
        }
    }
}