using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Assignment_Week_6.Models.Entities
{
    public class Product
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
