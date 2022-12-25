using Assignment_Week_6.Models.Entities;
using System.Linq.Expressions;

namespace Assignment_Week_6.Data.Repository.IRepository
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        IQueryable<Product> GetById(Expression<Func<Product, bool>> expression);
        void Create(Product product);
        void Delete(Product product);
        void Update(Product product);
       
    }
}
