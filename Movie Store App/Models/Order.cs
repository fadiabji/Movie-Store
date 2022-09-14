using System.ComponentModel.DataAnnotations;

namespace Movie_Store_App.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

    }
}
