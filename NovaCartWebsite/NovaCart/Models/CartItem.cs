namespace YourProject.Models
{
    public class CartItem
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Size { get; set; }
    }
}