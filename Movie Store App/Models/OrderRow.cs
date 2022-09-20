using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Store_App.Models
{
    public class OrderRow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public decimal Price { get; set; }

        static void Add(int orderId,int moveiId, decimal price)
        {
            OrderRow orderRow = new OrderRow();
            orderRow.OrderId = orderId;
            orderRow.MovieId = moveiId;
            orderRow.Price = price;
        }

        static decimal PriceCount(int moveiId)
        {
            
        }
    }
}
