namespace Application.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}