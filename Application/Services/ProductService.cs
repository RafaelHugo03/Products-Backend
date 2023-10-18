using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Contracts;
using Domain.Commands.Product;
using Domain.Repositories;
using FluentValidation.Results;
using Infra.Bus;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;
        private IMediatorHandler mediatorHandler;

        public ProductService(
            IProductRepository productRepository,
            IMediatorHandler mediatorHandler
        )
        {
            this.productRepository = productRepository;
            this.mediatorHandler = mediatorHandler;
        }

        public async Task<ValidationResult> Create(CreateProductCommand command)
        {
            return await mediatorHandler.SendCommand(command);
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand(id);

            return await mediatorHandler.SendCommand(command);
        }

        public async Task<ValidationResult> Edit(EditProductCommand command)
        {
            return await mediatorHandler.SendCommand(command);
        }

        public List<ProductDTO> GetProducts()
        {
            var products = productRepository.GetAll();

            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                CreatedAt = p.CreatedAt,
                Name = p.Name,
                Price = p.Price,
                UserId = p.UserId,
                UserName = p.User.Name
            }).ToList();
        }
    }
}