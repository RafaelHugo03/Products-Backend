using Application.DTOs;
using Domain.Commands.Product;
using FluentValidation.Results;

namespace Application.Services.Contracts
{
    public interface IProductService
    {
        Task<ValidationResult> Create(CreateProductCommand command);
        Task<ValidationResult> Edit(EditProductCommand command);
        Task<ValidationResult> Delete(Guid id);
        List<ProductDTO> GetProducts();
    }
}