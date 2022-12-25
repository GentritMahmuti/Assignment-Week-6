using Assignment_Week_6.Models.DTOs;
using Assignment_Week_6.Services.Commands;
using Assignment_Week_6.Services.IService;
using Assignment_Week_6.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_Week_6.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;
        public ProductController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }
        [HttpGet("GetProduct")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);
            return Ok(product);

        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
  
        }

        [HttpPost("PostProduct")]
        public async Task<IActionResult> Post([FromForm] ProductCreateDto ProductToCreate)
        {
            var command = new CreateProductCommand(ProductToCreate.Title, ProductToCreate.Description, ProductToCreate.Seller, ProductToCreate.Price);
            var productCreatedString = await _mediator.Send(command);
            return Ok(productCreatedString);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update(ProductDto ProductToUpdate)
        {
            var command = new UpdateProductCommand(ProductToUpdate.Id, ProductToUpdate.Title, ProductToUpdate.Description, ProductToUpdate.Seller, ProductToUpdate.Price);
            var productUpdatedString = await _mediator.Send(command);
            return Ok(productUpdatedString);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(int id)
        {
            var command= new DeleteProductCommand(id);
            var productDeletedString = await _mediator.Send(command);
            return Ok(productDeletedString);

        }
    }
}
