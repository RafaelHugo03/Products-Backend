using Application.DTOs;
using Domain.Commands.User;
using FluentValidation.Results;

namespace Application.Services.Contracts
{
    public interface IUserService
    {
        Task<ValidationResult> Create(CreateUserCommand command);
        Task<ValidationResult> Edit(EditUserCommand command);
        Task<ValidationResult> Delete(Guid id);
        List<UserDTO> GetUsers();
    }
}