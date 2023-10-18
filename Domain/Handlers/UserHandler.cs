using Domain.Commands.User;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation.Results;
using MediatR;

namespace Domain.Handlers
{
    public class UserHandler : CommandHandler,
        IRequestHandler<CreateUserCommand, ValidationResult>,
        IRequestHandler<EditUserCommand, ValidationResult>,
        IRequestHandler<DeleteUserCommand, ValidationResult>
    {
        private readonly IUserRepository userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<ValidationResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                AddError("Comando inválido");
                return command.ValidationResult;
            } 

            var existsCpf = userRepository.GetUserByCpf(command.Cpf) != null;

            if(existsCpf)
            {
                AddError("Já existe um usuário cadastrado com esse cpf");
                return ValidationResult;
            }

            var existsEmail = userRepository.GetUserByEmail(command.Email) != null;

            if(existsEmail)
            {
                AddError("Já existe um usuário cadastrado com esse e-mail");
                return ValidationResult;
            }

            var user = new User(command.Id, command.CreatedAt, command.Name, command.Email, command.Cpf);

            userRepository.Create(user);

            return Commit(userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                AddError("Comando inválido");
                return command.ValidationResult;
            } 

            var userByCpf = userRepository.GetUserByCpf(command.Cpf);
            if(userByCpf != null && userByCpf.Id != command.Id)
            {
                AddError("Já existe um usuário cadastrado com esse cpf");
                return ValidationResult;
            }

            var userByEmail = userRepository.GetUserByEmail(command.Email);

            if(userByEmail != null && userByEmail.Id != command.Id)
            {
                AddError("Já existe um usuário cadastrado com esse e-mail");
                return ValidationResult;
            }

            var user = userRepository.GetById(command.Id);
            user.Name = command.Name;
            user.Email = command.Email;
            user.Cpf = command.Cpf;

            userRepository.Edit(user);

            return Commit(userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid())
            {
                AddError("Comando inválido");
                return command.ValidationResult;
            } 

            userRepository.Delete(command.Id);

            return Commit(userRepository.UnitOfWork);
        }
    }
}