using Domain.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class BlogCategoryMap : IEntityTypeConfiguration<Domain.Entities.Blog.CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Category", "Blog");
        builder.HasQueryFilter(f => f.IsDeleted == false);
        builder.HasMany(m => m.Articles)
            .WithOne(o => o.Category)
            .HasForeignKey(f => f.CategoryId);
    }
}
