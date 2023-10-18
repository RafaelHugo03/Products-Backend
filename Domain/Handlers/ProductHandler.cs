using Domain.Commands.Product;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation.Results;
using MediatR;

namespace Domain.Handlers
{
    public class ProductHandler : CommandHandler,
        IRequestHandler<CreateProductCommand, ValidationResult>,
        IRequestHandler<EditProductCommand, ValidationResult>,
        IRequestHandler<DeleteProductCommand, ValidationResult>
        
    {
        private readonly IProductRepository productRepository;

        public ProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ValidationResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                AddError("Comando inválido");
                return command.ValidationResult;
            } 

            var product = new Product(command.Id, 
                command.CreatedAt, 
                command.Name, 
                command.Price, 
                command.UserId);
            
            productRepository.Create(product);

            return Commit(productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditProductCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                AddError("Comando inválido");
                return command.ValidationResult;
            } 

            var product = productRepository.GetById(command.Id);

            product.Name = command.Name;
            product.Price = command.Price;
            product.UserId = command.UserId;
            
            productRepository.Edit(product);

            return Commit(productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                AddError("Comando inválido");
                return command.ValidationResult;
            } 

            productRepository.Delete(command.Id);

            return Commit(productRepository.UnitOfWork);
        }
    }
}