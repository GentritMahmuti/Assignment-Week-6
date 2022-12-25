using MediatR;

namespace Assignment_Week_6.Services.Commands
{
    public class UpdateProductCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Seller { get; set; }
        public double Price { get; set; }

        public UpdateProductCommand(int id, string title, string description, string seller, double price)
        {
            Id = id;
            Title = title;
            Description = description;
            Seller = seller;
            Price = price;
        }
    }
}
