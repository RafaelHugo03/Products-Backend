using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Contracts;
using Domain.Commands.User;
using Domain.Repositories;
using FluentValidation.Results;
using Infra.Bus;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IMediatorHandler mediatorHandler;

        public UserService(
            IUserRepository userRepository,
            IMediatorHandler mediatorHandler
        )
        {
            this.userRepository = userRepository;
            this.mediatorHandler = mediatorHandler;
        }

        public async Task<ValidationResult> Create(CreateUserCommand command)
        {
            return await mediatorHandler.SendCommand(command);
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(
                id
            );

            return await mediatorHandler.SendCommand(command);
        }

        public async Task<ValidationResult> Edit(EditUserCommand command)
        {
            return await mediatorHandler.SendCommand(command);
        }

        public List<UserDTO> GetUsers()
        {
            var users = userRepository.GetAll();

            return users.Select(u => new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Cpf = u.Cpf,
                    Email = u.Email,    
                    CreatedAt = u.CreatedAt
                }).ToList();
        }
    }
}