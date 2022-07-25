namespace DAL.Models
{
    public class OrderItemModel
    {
        public Guid Id { get; set; }
        public ProductModel Product { get; set; }
        public decimal FinalPrice { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

    }


}
