using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public CustomerModel Customer { get; set; }
        public IEnumerable<OrderItemModel> Items { get; set; }
        public DateTime OrderedDate { get; set; }
        public string MyProperty { get; set; }
    }
}
