using System.ComponentModel.DataAnnotations;

namespace Task.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Envanter> Envanters { get; set; }
    }
}
