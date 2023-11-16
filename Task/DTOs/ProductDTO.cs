using System.ComponentModel.DataAnnotations;

namespace Task.DTOs
{
    public class ProductDTO
    {
        
        [Required]
        public double Price { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string BrandName { get; set; }
    }
}
