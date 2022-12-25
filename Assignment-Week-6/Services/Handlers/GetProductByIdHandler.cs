using Assignment_Week_6.Models.Entities;
using Assignment_Week_6.Services.IService;
using Assignment_Week_6.Services.Queries;
using MediatR;

namespace Assignment_Week_6.Services.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductService _productService;
        public GetProductByIdHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProduct(request.Id);
            return product;
        }
    }
}
