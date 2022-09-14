namespace Movie_Store_App.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }

        public int Lastname { get; set; }

        public string Emailaddress { get; set; }

        public string BillingCity { get; set; }


        public string BillingAddress { get; set; }
        public string BillingZip { get; set; }


        public string DeliveryCity { get; set; }

        public string DeliveryAddress { get; set; }
        public string DeliveryZip { get; set; }

        public int PhoneNumber { get; set; }

    }
}

