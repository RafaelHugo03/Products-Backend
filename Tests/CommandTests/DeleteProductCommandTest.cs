using Domain.Commands.Product;

namespace Tests.CommandTests
{
    [TestClass]
    public class DeleteProductCommandTest
    {
        [TestMethod]
        public void Id_Invalido_Deve_Ser_Invalido()
        {
            var command = new DeleteProductCommand(Guid.Empty);

            Assert.AreEqual(false, command.IsValid());
        }

        [TestMethod]
        public void Command_Valido_Deve_Ser_Valido()
        {
            var command = new DeleteProductCommand(Guid.NewGuid());

            Assert.AreEqual(true, command.IsValid());
        }
    }
}