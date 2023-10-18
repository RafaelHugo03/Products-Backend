using Domain.Commands.User;

namespace Tests.CommandTests
{
    [TestClass]
    public class CreateUserCommandTest
    {
        [TestMethod]
        public void Nome_Invalido_Deve_Ser_Invalido()
        {
            var command = new CreateUserCommand("", "12345678912", "rafaelhugo@outlook.com");

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Email_Invalido_Deve_Ser_Invalido()
        {
            var command = new CreateUserCommand("Rafael", "12345678912", "rafaelhugo");

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Cpf_Invalido_Deve_Ser_Invalido()
        {
            var command = new CreateUserCommand("Rafael", "123456789", "rafaelhugo03@outlook.com");

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Command_Valido_Deve_Ser_Valido()
        {
            var command = new CreateUserCommand("Rafael", "12345678912", "rafaelhugo03@outlook.com");

            Assert.AreEqual(true, command.IsValid());
        }
    }
}