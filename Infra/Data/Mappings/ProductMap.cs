using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnType("uniqueidentifier");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("datetime");
            builder.Property(p => p.Name).HasColumnName("name").HasMaxLength(150).HasColumnType("varchar");
            builder.Property(p => p.Price).HasColumnName("price").HasColumnType("decimal");
            builder.Property(p => p.UserId).HasColumnName("user_id").HasColumnType("uniqueidentifier");

            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
        }
    }
}