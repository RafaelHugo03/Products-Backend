using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commands.User;

namespace Tests.CommandTests
{
    [TestClass]
    public class DeleteUserCommandTest
    {
        [TestMethod]
        public void Id_Invalido_Deve_Ser_Invalido()
        {
            var command = new DeleteUserCommand(Guid.Empty);

            Assert.AreEqual(false, command.IsValid());
        }

        
        [TestMethod]
        public void Command_Valido_Deve_Ser_Valido()
        {
            var command = new DeleteUserCommand(Guid.NewGuid());

            Assert.AreEqual(true, command.IsValid());
        }
    }
}