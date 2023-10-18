using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Commands.Product;
using Domain.Commands.User;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using FluentValidation.Results;
using Infra.Bus;
using Infra.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Dependencies
{
    public static class DependencyInjector
    {
        public static void InjectInfraDependencies(this IServiceCollection services)
        {
            AddMediatr(services);
            AddHandlers(services);
            AddRepositories(services);
        }

        private static void AddMediatr(IServiceCollection services)
        {
            services.AddMediatR(
                p => p.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }
        private static void AddHandlers(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateUserCommand, ValidationResult>, UserHandler>();
            services.AddScoped<IRequestHandler<EditUserCommand, ValidationResult>, UserHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, ValidationResult>, UserHandler>();

            services.AddScoped<IRequestHandler<CreateProductCommand, ValidationResult>, ProductHandler>();
            services.AddScoped<IRequestHandler<EditProductCommand, ValidationResult>, ProductHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, ValidationResult>, ProductHandler>();
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}