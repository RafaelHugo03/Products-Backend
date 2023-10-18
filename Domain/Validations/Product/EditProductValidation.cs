using Domain.Commands.Product;

namespace Domain.Validations.Product
{
    public class EditProductValidation : ProductCommandValidations<EditProductCommand>
    {
        public EditProductValidation()
        {
            ValidateId();
            ValidateName();
            ValidatePrice();
            ValidateUserId();
        }
    }
}