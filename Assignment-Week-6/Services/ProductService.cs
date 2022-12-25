using Assignment_Week_6.Common.Constants;
using Assignment_Week_6.Data.Repository.IRepository;
using Assignment_Week_6.Models.DTOs;
using Assignment_Week_6.Models.Entities;
using Assignment_Week_6.Services.IService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System.Linq.Expressions;
using System.Text.Json;

namespace Assignment_Week_6.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public ProductService(IProductRepository productRepository, IMapper mapper, IMemoryCache memoryCache, IConnectionMultiplexer connectionMultiplexer)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<Product> GetProduct(int id)
        {
            var cachedProduct = await _memoryCache.GetOrCreateAsync(String.Format(ProductCacheKeyConstants.GetById, id), async entity =>
            {
                Expression<Func<Product, bool>> expression = x => x.Id == id;
                var product = await _productRepository.GetById(expression).FirstOrDefaultAsync();

                return product;
            });
            var distributedCachedProduct = _connectionMultiplexer.GetDatabase().StringGet(String.Format(ProductCacheKeyConstants.GetById, id));
            return cachedProduct;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var products = _productRepository.GetAll();

            return products.ToList();
        }

        public async Task CreateProduct(ProductCreateDto productToCreate)
        {
            var product = _mapper.Map<Product>(productToCreate);

            _productRepository.Create(product);

            _memoryCache.Set<Product>(String.Format(ProductCacheKeyConstants.GetById, product.Id), product, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(20),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(8)
            });
            string jsonString = JsonSerializer.Serialize(product);
            _connectionMultiplexer.GetDatabase().StringSet("HI", jsonString);
        }

        
        public async Task UpdateProduct(ProductDto productToUpdate)
        {
            Product product = null;
            if (!_memoryCache.TryGetValue(String.Format(ProductCacheKeyConstants.GetById, productToUpdate.Id), out object result))
            {
                product = await GetProduct(productToUpdate.Id);
                if (product == null)
                {
                    return;
                }
            }

            product.Title = productToUpdate.Title;
            product.Description = productToUpdate.Description;
            product.Price = productToUpdate.Price;

            _productRepository.Update(product);

            _memoryCache.Set<Product>(String.Format(ProductCacheKeyConstants.GetById, product.Id), product, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(20),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(8)
            });

        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProduct(id);

            _productRepository.Delete(product);

            _memoryCache.Remove(String.Format(ProductCacheKeyConstants.GetById, product.Id));

            _connectionMultiplexer.GetDatabase().KeyDelete("HI"/*String.Format(ProductCacheKeyConstants.GetById, product.Id)*/);
        }

        
    }
}
