using Assignment_Week_6.Models.DTOs;
using Assignment_Week_6.Models.Entities;
using Assignment_Week_6.Services.Commands;
using Assignment_Week_6.Services.IService;
using AutoMapper;
using MediatR;

namespace Assignment_Week_6.Services.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductService _productService;
        public CreateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ProductCreateDto productToCreate = new ProductCreateDto
            {
                Title = request.Title,
                Description = request.Description,
                Seller = request.Seller,
                Price = request.Price
            };
            await _productService.CreateProduct(productToCreate);
            return "Product created successfully!";
        }
    }
}
