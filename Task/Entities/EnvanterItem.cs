using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task.Entities
{
    public class EnvanterItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Parcel { get; set; }
        public int EnvanterId { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
        public Envanter Envanter { get; set; }
    }
}
