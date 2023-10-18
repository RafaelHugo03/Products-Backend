namespace Domain.Commands.User
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Cpf { get; protected set; }
    }
}