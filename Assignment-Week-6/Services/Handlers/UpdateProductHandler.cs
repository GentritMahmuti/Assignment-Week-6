using Assignment_Week_6.Models.DTOs;
using Assignment_Week_6.Services.Commands;
using Assignment_Week_6.Services.IService;
using MediatR;

namespace Assignment_Week_6.Services.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IProductService _productService;
        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            ProductDto productToUpdate = new ProductDto
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Seller = request.Seller,
                Price = request.Price
            };
            await _productService.UpdateProduct(productToUpdate);
            return "Product updated successfully!";
        }
    }
}
