using System.ComponentModel.DataAnnotations;

namespace Assignment_Week_6.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Seller { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
