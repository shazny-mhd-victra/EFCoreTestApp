using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public DateTime DOB { get; set; }
        //public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //public string Contact { get; set; }
        [Required]
        public string Status { get; set; }


    }
}
