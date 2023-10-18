

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product
        (
            Guid id,
            DateTime createdAt,
            string name,
            decimal price,
            Guid userId
        )
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.Name = name;
            this.Price = price;
            this.UserId = userId;
        }
        public string Name { get; internal set; }
        public decimal Price { get; internal set; }
        public Guid UserId { get; internal set; }
        public User User { get; internal set; }
    }
}