using System.ComponentModel.DataAnnotations;

namespace Customer_Management_System.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [Required]
        public int PinCode { get; set; }
    }
}
