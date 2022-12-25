using Assignment_Week_6.Models.Entities;
using MediatR;

namespace Assignment_Week_6.Services.Queries
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {

    }
}
