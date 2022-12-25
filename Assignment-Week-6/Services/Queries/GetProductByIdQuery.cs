using Assignment_Week_6.Models.Entities;
using MediatR;

namespace Assignment_Week_6.Services.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get;}

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
