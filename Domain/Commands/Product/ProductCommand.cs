namespace Domain.Commands.Product
{
    public class ProductCommand : Command
    {
        
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public Guid UserId { get; protected set; }

    }
}