namespace YourProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string PaymentMethod { get; set; }

        public decimal Total { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}