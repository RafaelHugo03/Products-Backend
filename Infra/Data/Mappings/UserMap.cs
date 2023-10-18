using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnType("uniqueidentifier");
            builder.Property(u => u.CreatedAt).HasColumnName("created_at").HasColumnType("datetime");
            builder.Property(u => u.Name).HasColumnName("name").HasMaxLength(150).HasColumnType("varchar");
            builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(150).HasColumnType("varchar");
            builder.Property(u => u.Cpf).HasColumnName("cpf").HasMaxLength(11).HasColumnType("varchar");
        }
    }
}