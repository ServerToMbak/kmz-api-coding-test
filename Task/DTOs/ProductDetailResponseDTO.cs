namespace Task.DTOs
{
    public class ProductDetailResponseDTO
    {
        public ProductDetailDTO ProductDetailDTO { get; set; }
        public List<ProductDTO> Suggestions { get; set; }
    }
}
