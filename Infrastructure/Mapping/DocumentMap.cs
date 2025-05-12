using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class DocumentMap :
    IEntityTypeConfiguration<DocumentEntity>
{
    public void Configure(EntityTypeBuilder<DocumentEntity> builder)
    {
        builder.ToTable("Document", "Product");
        builder.HasQueryFilter(f => f.IsDeleted == false);
        builder.HasOne(o => o.Product)
            .WithMany(m => m.Documents)
            .HasForeignKey(f => f.ProductId);
    }
}
