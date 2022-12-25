using Assignment_Week_6.Models.Entities;
using Assignment_Week_6.Services.IService;
using Assignment_Week_6.Services.Queries;
using MediatR;

namespace Assignment_Week_6.Services.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductService _productService;
        public GetAllProductsHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProducts();

            return products;
        }
    }
}
