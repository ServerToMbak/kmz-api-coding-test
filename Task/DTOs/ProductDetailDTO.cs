namespace Task.DTOs
{
    public class ProductDetailDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string BrandName { get; set; } // Comes from Envanter Entity
        public string CategoryName { get; set; }
        public int Parcel { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }  // Comes from Envaneter Entity
    }
}
