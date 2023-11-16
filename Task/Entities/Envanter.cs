using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Entities
{
    public class Envanter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Column("quantity")]
        public int QuantityInStock { get; set; }
        public string SKUCode { get; set; }
        public Category Category { get; set; }
        public string? BrandName { get; set; }  
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
    }
}
