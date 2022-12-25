using Assignment_Week_6.Services.Queries;
using MediatR;

namespace Assignment_Week_6.Services.Commands
{
    public class DeleteProductCommand : IRequest<string>
    {
        public int Id { get; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
