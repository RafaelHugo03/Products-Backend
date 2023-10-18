using Domain.Commands.Product;

namespace Tests.CommandTests
{
    [TestClass]
    public class EditProductCommandTest
    {
        [TestMethod]
        public void Id_Invalido_Deve_Ser_Invalido()
        {
            var command = new EditProductCommand(Guid.Empty, "Martelo", 10, Guid.NewGuid());

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Nome_Invalido_Deve_Ser_Invalido()
        {
            var command = new EditProductCommand(Guid.NewGuid(), "", 10, Guid.NewGuid());

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Preco_Invalido_Deve_Ser_Invalido()
        {
            var command = new EditProductCommand(Guid.NewGuid() ,"Martelo", -1, Guid.NewGuid());

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void UserId_Invalido_Deve_Ser_Invalido()
        {
            var command = new EditProductCommand(Guid.NewGuid(), "Martelo", 10, Guid.Empty);

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Command_Valido_Deve_Ser_Valido()
        {
            var command = new EditProductCommand(Guid.NewGuid(), "Martelo", 10, Guid.NewGuid());

            Assert.AreEqual(true, command.IsValid());
        }
    }
}