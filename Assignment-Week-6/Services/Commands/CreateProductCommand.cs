using Assignment_Week_6.Models.DTOs;
using Assignment_Week_6.Models.Entities;
using MediatR;

namespace Assignment_Week_6.Services.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Seller { get; set; }
        public double Price { get; set; }

        public CreateProductCommand(string title, string description, string seller, double price)
        {
            Title = title;
            Description = description;
            Seller = seller;
            Price = price;
        }

    }
}
