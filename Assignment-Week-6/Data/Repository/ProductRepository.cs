using Assignment_Week_6.Data.Repository.IRepository;
using Assignment_Week_6.Models.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Assignment_Week_6.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly LifeDbContext _dbContext;

        public ProductRepository(LifeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> GetAll()
        {
            var result = _dbContext.Set<Product>();
            return result;
        }

        public IQueryable<Product> GetById(Expression<Func<Product, bool>> expression)
        {
            return _dbContext.Set<Product>().Where(expression);
        }
        public void Create(Product product)
        {
            _dbContext.Set<Product>().Add(product);
            _dbContext.SaveChanges();
        }
        public void Update(Product product)
        {
            _dbContext.Set<Product>().Update(product);
            _dbContext.SaveChanges();
        }
        public void Delete(Product product)
        {
            _dbContext.Set<Product>().Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
