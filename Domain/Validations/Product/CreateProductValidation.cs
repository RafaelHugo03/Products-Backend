using Domain.Commands.Product;

namespace Domain.Validations.Product
{
    public class CreateProductValidation : ProductCommandValidations<CreateProductCommand>
    {
        public CreateProductValidation()
        {
            ValidateName();
            ValidatePrice();
            ValidateUserId();
        }
    }
}