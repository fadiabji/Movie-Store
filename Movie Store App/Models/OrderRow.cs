using System.ComponentModel.DataAnnotations;

namespace Movie_Store_App.Models
{
    public class OrderRow
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public decimal Price { get; set; }
       
    }
}
