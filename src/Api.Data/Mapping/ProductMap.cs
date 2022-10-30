using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Code)
                   .IsUnique();

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Status)
                   .IsRequired();

            builder.Property(p => p.DateFabrication);

            builder.Property(p => p.DateExpiry);

            builder.Property(p => p.SupplierCode);

            builder.Property(p => p.SupplierDescription);

            builder.Property(p => p.SupplierCnpj);

        }
    }
}
