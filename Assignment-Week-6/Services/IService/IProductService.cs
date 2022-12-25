using Assignment_Week_6.Models.DTOs;
using Assignment_Week_6.Models.Entities;

namespace Assignment_Week_6.Services.IService
{
    public interface IProductService
    {
        Task CreateProduct(ProductCreateDto productToCreate);
        Task DeleteProduct(int id);
        Task UpdateProduct(ProductDto productToUpdate);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
    }
}
