namespace Task.DTOs
{
    public class ProductDetailDTO
    {   
        public string Name { get; set; }
        public string? Description { get; set; }
        public string BrandName { get; set; } // Comes from Envanter Entity
        public string CategoryName { get; set; }
        public ICollection<EnvanterItemDTO> EnvanterItems { get; set; }
        public double Price { get; set; }
    }
}
