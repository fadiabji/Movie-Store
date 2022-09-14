namespace Movie_Store_App.Models
{
    public class Order
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

    }
}
