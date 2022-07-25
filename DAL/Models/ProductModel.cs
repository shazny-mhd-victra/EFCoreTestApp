using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public int QuantityAvailable { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
