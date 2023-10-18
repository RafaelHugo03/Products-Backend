using Domain.Commands.User;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Moq;
using Tests.Utils;

namespace Tests.HandlerTests
{
    [TestClass]
    public class UserHandlerTest
    {
        private readonly Mock<IUserRepository> userRepository;
        private readonly UserHandler userHandler;
        private User user;
        private Delegate @delegate = Utility.RetornaUsuarioNulo;
        private CreateUserCommand createUserCommand;
        private EditUserCommand editUserCommand;

        public UserHandlerTest()
        {
            userRepository = new();
            userHandler = new UserHandler(userRepository.Object);

            user = new User(Guid.NewGuid(), DateTime.Now, "Rafael", "rafael@outlook.com", "12345678912");
            createUserCommand = new CreateUserCommand("Rafael", "12345678912", "rafael@outlook.com");
            editUserCommand = new EditUserCommand(Guid.NewGuid(), "Rafael", "rafael@outlook.com", "12345678912");
        }

        [TestMethod]
        public void CreateUser_Handler_com_cpf_existente_deve_ser_invalido()
        {
            userRepository.Setup(u => u.GetUserByCpf(createUserCommand.Cpf)).Returns(user);

            userHandler.Handle(createUserCommand, new CancellationToken());

            Assert.AreEqual(false, userHandler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void CreateUser_Handler_com_comando_inválido_deve_ser_invalido()
        {
            var invalidCommand = new CreateUserCommand("", "", "");
            userRepository.Setup(u => u.GetUserByCpf(invalidCommand.Cpf)).Returns(@delegate);

            userHandler.Handle(invalidCommand, new CancellationToken());

            Assert.AreEqual(false, userHandler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void CreateUser_Handler_com_email_existente_deve_ser_invalido()
        {
            userRepository.Setup(u => u.GetUserByEmail(createUserCommand.Email)).Returns(user);

            userHandler.Handle(createUserCommand, new CancellationToken());

            Assert.AreEqual(false, userHandler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void CreateUser_Handler_Deve_Ser_Valido()
        {
            userRepository.Setup(u => u.GetUserByEmail(createUserCommand.Email)).Returns(@delegate);
            userRepository.Setup(u => u.GetUserByCpf(createUserCommand.Email)).Returns(@delegate);

            userHandler.Handle(createUserCommand, new CancellationToken());

            Assert.AreEqual(true, userHandler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void EditUser_Handler_com_cpf_existente_deve_ser_invalido()
        {
            userRepository.Setup(u => u.GetUserByCpf(editUserCommand.Cpf)).Returns(user);

            userHandler.Handle(editUserCommand, new CancellationToken());

            Assert.AreEqual(false, userHandler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void EditUser_Handler_com_comando_invalido_deve_ser_invalido()
        {
            var invalidCommand = new EditUserCommand(Guid.Empty, "", "", "");
            userRepository.Setup(u => u.GetUserByCpf(invalidCommand.Cpf)).Returns(@delegate);

            userHandler.Handle(invalidCommand, new CancellationToken());

            Assert.AreEqual(false, userHandler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void EditUser_Handler_com_email_existente_deve_ser_invalido()
        {
            userRepository.Setup(u => u.GetUserByEmail(editUserCommand.Email)).Returns(user);

            userHandler.Handle(editUserCommand, new CancellationToken());

            Assert.AreEqual(false, userHandler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void EditUser_Handler_Deve_Ser_Valido()
        {
            userRepository.Setup(u => u.GetUserByEmail(editUserCommand.Email)).Returns(@delegate);
            userRepository.Setup(u => u.GetUserByCpf(editUserCommand.Email)).Returns(@delegate);

            userHandler.Handle(editUserCommand, new CancellationToken());

            Assert.AreEqual(true, userHandler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void DeleteUser_Handler_Com_Commando_Valido_Deve_Ser_Valido()
        {
            var command = new DeleteUserCommand(Guid.NewGuid());
            userHandler.Handle(command, new CancellationToken());

            Assert.AreEqual(true, userHandler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void DeleteUser_Handler_Com_Commando_InValido_Deve_Ser_InValido()
        {
            var command = new DeleteUserCommand(Guid.Empty);
            userHandler.Handle(command, new CancellationToken());

            Assert.AreEqual(false, userHandler.ValidationResult.IsValid);
        }
    }
}