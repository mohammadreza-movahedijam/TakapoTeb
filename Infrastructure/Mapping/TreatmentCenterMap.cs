using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class TreatmentCenterMap :
    IEntityTypeConfiguration<TreatmentCenterEntity>
{
    public void Configure(EntityTypeBuilder<TreatmentCenterEntity> builder)
    {
        builder.ToTable("TreatmentCenter", "Product");
        builder.HasQueryFilter(f => f.IsDeleted == false);
        builder.HasOne(o => o.Product)
            .WithMany(m => m.TreatmentCenters)
            .HasForeignKey(f => f.ProductId);
    }
}
