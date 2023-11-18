using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Entities
{
    public class Envanter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public string SKUCode { get; set; }
        public ICollection<EnvanterItem> EnvanterItems { get; set; }
    }
}
