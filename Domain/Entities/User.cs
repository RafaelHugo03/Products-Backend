using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User(
            Guid id,
            DateTime createdAt,
            string name,
            string email,
            string cpf
        )
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.Name = name;
            this.Email = email;
            this.Cpf = cpf;
        }

        public string Name { get; internal set; }
        public string Email { get; internal set; }
        public string Cpf { get; internal set; }
    }
}