using Application.Services.Contracts;
using Domain.Commands.Product;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("products")]
    public class ProductController : ApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(productService.GetProducts());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            return CustomResponse(await productService.Create(command));
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] EditProductCommand Command)
        {
            return CustomResponse(await productService.Edit(Command));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return CustomResponse(await productService.Delete(id));
        }
    }
}