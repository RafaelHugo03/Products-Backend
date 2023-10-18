using Domain.Commands.Product;

namespace Tests.CommandTests
{
    [TestClass]
    public class CreateProductCommandTest
    {
        [TestMethod]
        public void Nome_Invalido_Deve_Ser_Invalido()
        {
            var command = new CreateProductCommand("", 10, Guid.NewGuid());

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Preco_Invalido_Deve_Ser_Invalido()
        {
            var command = new CreateProductCommand("Martelo", -1, Guid.NewGuid());

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void UserId_Invalido_Deve_Ser_Invalido()
        {
            var command = new CreateProductCommand("Martelo", 10, Guid.Empty);

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Command_Valido_Deve_Ser_Valido()
        {
            var command = new CreateProductCommand("Martelo", 10, Guid.NewGuid());

            Assert.AreEqual(true, command.IsValid());
        }
    }
}