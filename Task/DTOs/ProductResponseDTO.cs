using System.ComponentModel.DataAnnotations;

namespace Task.DTOs
{
    public class ProductResponseDTO
    {
        [Required]
        public int QuantityInStock { get; set; }
        public List<ProductDTO>? Products { get; set; }
    
    }
}
