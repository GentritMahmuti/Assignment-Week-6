using Assignment_Week_6.Services.Commands;
using Assignment_Week_6.Services.IService;
using MediatR;

namespace Assignment_Week_6.Services.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProductService _productService;
        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProduct(request.Id);

            return "Product deleted successfully!";
        }
    }
}
