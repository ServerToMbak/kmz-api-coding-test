using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        
        public ICollection<EnvanterItem> EnvanterItems { get; set; }
        public string? BrandName { get; set; }
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}
