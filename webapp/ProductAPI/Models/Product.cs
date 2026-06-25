namespace ProductAPI.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty; // "" 입력 가능
        //  ? nullable
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}