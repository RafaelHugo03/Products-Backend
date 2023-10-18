using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commands.User;

namespace Tests.CommandTests
{
    [TestClass]
    public class EditUserCommandTest
    {
        [TestMethod]
        public void Nome_Invalido_Deve_Ser_Invalido()
        {
            var command = new EditUserCommand(Guid.NewGuid(), "", "12345678912", "rafaelhugo@outlook.com");

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Id_Invalido_Deve_Ser_Invalido()
        {
            var command = new EditUserCommand(Guid.Empty, "Rafael", "rafaelhugo03@outlook.com", "12345678912");

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Email_Invalido_Deve_Ser_Invalido()
        {
            var command = new EditUserCommand(Guid.NewGuid(), "Rafael", "rafaelhugo", "12345678912");

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Cpf_Invalido_Deve_Ser_Invalido()
        {
            var command = new EditUserCommand(Guid.NewGuid(), "Rafael", "rafaelhugo03@outlook.com", "123456789");

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Command_Valido_Deve_Ser_Valido()
        {
            var command = new EditUserCommand(Guid.NewGuid(), "Rafael", "rafaelhugo03@outlook.com", "12345678912");

            Assert.AreEqual(true, command.IsValid());
        }
    }
}