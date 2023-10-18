namespace Application.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}