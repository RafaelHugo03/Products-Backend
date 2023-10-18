using Domain.Commands.Product;
using Domain.Handlers;
using Domain.Repositories;
using Moq;

namespace Tests.HandlerTests
{
    [TestClass]
    public class ProductHandlerTest
    {
        private readonly Mock<IProductRepository> productRepository;
        private readonly ProductHandler handler;

        public ProductHandlerTest()
        {
            productRepository = new();
            handler = new ProductHandler(productRepository.Object);
        }

        [TestMethod]
        public void CreateProduct_Com_Comando_Invalido_Deve_Ser_Invalido()
        {
            var invalidCommand = new CreateProductCommand("", -1, Guid.Empty);

            handler.Handle(invalidCommand, new CancellationToken());

            Assert.AreEqual(false, handler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void CreateProduct_Com_Comando_Valido_Deve_Ser_Valido()
        {
            var command = new CreateProductCommand("Martelo", 10, Guid.NewGuid());

            handler.Handle(command, new CancellationToken());

            Assert.AreEqual(true, handler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void EditProduct_Com_Comando_Valido_Deve_Ser_Valido()
        {
            var command = new EditProductCommand(Guid.NewGuid(),"Martelo", 10, Guid.NewGuid());

            handler.Handle(command, new CancellationToken());

            Assert.AreEqual(true, handler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void EditProduct_Com_Comando_Invalido_Deve_Ser_Invalido()
        {
            var invalidCommand = new EditProductCommand(Guid.Empty,"", -1, Guid.Empty);

            handler.Handle(invalidCommand, new CancellationToken());

            Assert.AreEqual(false, handler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void DeleteProduct_Com_Comando_Invalido_Deve_Ser_Invalido()
        {
            var invalidCommand = new DeleteProductCommand(Guid.Empty);

            handler.Handle(invalidCommand, new CancellationToken());

            Assert.AreEqual(false, handler.ValidationResult.IsValid);
        }

        [TestMethod]
        public void Delete_Com_Comando_Valido_Deve_Ser_Valido()
        {
            var command = new DeleteProductCommand(Guid.NewGuid());

            handler.Handle(command, new CancellationToken());

            Assert.AreEqual(true, handler.ValidationResult.IsValid);
        }
    }
}