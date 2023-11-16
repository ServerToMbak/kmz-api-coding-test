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
        public int Parcel { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Envanter Envanter { get; set; }
        [ForeignKey("Envanters")]
        public int EnvanterId { get; set; }
    }
}
