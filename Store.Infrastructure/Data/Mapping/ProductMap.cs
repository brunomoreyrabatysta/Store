using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.Mapping;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(160)
            .HasColumnType("VARCHAR");
    }
}
